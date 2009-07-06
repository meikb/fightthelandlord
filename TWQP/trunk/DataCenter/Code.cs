using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Remoting.Messaging;

namespace ContactCenter
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IContactCenterCallback))]
    interface IContactCenter
    {
        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        int[] Join(int id);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Say(byte[][] data);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Whisper(int to, byte[][] data);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave();
    }

    interface IContactCenterCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive(int senderId, byte[][] data);

        [OperationContract(IsOneWay = true)]
        void ReceiveWhisper(int senderId, byte[][] data);

        [OperationContract(IsOneWay = true)]
        void ServiceEnter(int id);

        [OperationContract(IsOneWay = true)]
        void ServiceLeave(int id);

        [OperationContract(IsOneWay = false)]
        bool Ping(byte[][] data);
    }


    public enum MessageType { Receive, ServiceEnter, ServiceLeave, ReceiveWhisper, Ping };

    public class MessageEventArgs : EventArgs
    {
        public MessageType MessageType;
        public int Id;
        public byte[][] Data;
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ContactCenterService : IContactCenter
    {
        private static Object _syncObj = new Object();
        private static Dictionary<int, MessageEventHandler> _services = new Dictionary<int, MessageEventHandler>();

        public static event MessageEventHandler MessageEvent;

        private int _id = 0;
        private MessageEventHandler _myEventHandler = null;
        private IContactCenterCallback _callbackInstance = null;
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public int[] Join(int id)
        {
            bool isAdded = false;
            _myEventHandler = (sender, e) =>
            {
                try
                {
                    switch (e.MessageType)
                    {
                        case MessageType.Receive:
                            _callbackInstance.Receive(e.Id, e.Data);
                            break;
                        case MessageType.ReceiveWhisper:
                            _callbackInstance.ReceiveWhisper(e.Id, e.Data);
                            break;
                        case MessageType.ServiceEnter:
                            _callbackInstance.ServiceEnter(e.Id);
                            break;
                        case MessageType.ServiceLeave:
                            _callbackInstance.ServiceLeave(e.Id);
                            break;
                        case MessageType.Ping:
                            _callbackInstance.Ping(e.Data);
                            break;
                    }
                }
                catch
                {
                    Leave();
                }
            };

            lock (_syncObj)
            {
                if (id != 0)
                {
                    if (!_services.ContainsKey(id))
                    {
                        this._id = id;
                        _services.Add(id, _myEventHandler);
                        isAdded = true;
                    }
                }
            }

            if (isAdded)
            {
                _callbackInstance = OperationContext.Current.GetCallbackChannel<IContactCenterCallback>();
                Broadcast(this, new MessageEventArgs { Id = id, MessageType = MessageType.ServiceEnter });
                MessageEvent += _myEventHandler;
                int[] list = new int[_services.Count];
                lock (_syncObj) _services.Keys.CopyTo(list, 0);
                return list;
            }
            else
            {
                return null;
            }
        }

        public void Say(byte[][] data)
        {
            Broadcast(this, new MessageEventArgs { MessageType = MessageType.Receive, Id = this._id, Data = data });
        }

        public void Whisper(int to, byte[][] data)
        {
            try
            {
                MessageEventHandler handler;
                lock (_syncObj) handler = _services[to];
                handler.BeginInvoke(this,
                    new MessageEventArgs { Id = this._id, Data = data, MessageType = MessageType.ReceiveWhisper },
                    new AsyncCallback(EndAsync), null);
            }
            catch (KeyNotFoundException)
            {
            }
        }

        public void Leave()
        {
            if (this._id == 0) return;
            lock (_syncObj) _services.Remove(this._id);
            MessageEvent -= _myEventHandler;
            Broadcast(this, new MessageEventArgs { Id = this._id, MessageType = MessageType.ServiceLeave });
        }

        public static void Broadcast(ContactCenterService sender, MessageEventArgs e)
        {
            var temp = MessageEvent;
            if (temp != null)
            {
                foreach (MessageEventHandler handler in temp.GetInvocationList())
                {
                    handler.BeginInvoke(sender, e, new AsyncCallback(EndAsync), null);
                }
            }
        }

        private static void EndAsync(IAsyncResult ar)
        {
            MessageEventHandler d = null;
            try
            {
                var asres = (AsyncResult)ar;
                d = (MessageEventHandler)asres.AsyncDelegate;
                d.EndInvoke(ar);
            }
            catch
            {
                MessageEvent -= d;
            }
        }

    }
}

