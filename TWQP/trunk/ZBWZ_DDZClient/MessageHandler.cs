using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZBWZ_DDZ;
using System.Threading;

namespace ZBWZ_DDZClient
{
    public static class MessageHandler
    {
        /// <summary>
        /// 处理程序
        /// </summary>
        public static Handler h { get; set; }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public static int PlayerID { get; set; }
        /// <summary>
        /// 代理ID
        /// </summary>
        public static int ProxyID { get; set; }
        /// <summary>
        /// 发送消息锁定标识
        /// </summary>
        public static object _sync_sendWhisper = new object();
        /// <summary>
        /// 接收消息锁定标识
        /// </summary>
        public static object _sync_ReceiveWhisper = new object();
        /// <summary>
        /// 接收消息列队
        /// </summary>
        public static Queue<KeyValuePair<int, byte[][]>> _receiveWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 发送消息列队
        /// </summary>
        public static Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        #region 发送数据
        public static void 发送_请求桌子数据()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_请求桌子数据) };
            发送数据(sendData);
        }

        public static void 发送_能否进入()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_能否进入) };
            发送数据(sendData);
        }

        public static void 发送_能否进入(int deskID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_能否进入), BitConverter.GetBytes(deskID) };
            发送数据(sendData);
        }

        public static void 发送_进入()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_进入) };
            发送数据(sendData);
        }


        public static void 发送_准备()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_准备) };
            发送数据(sendData);
        }

        public static void 发送_叫地主()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_叫地主) };
            发送数据(sendData);
        }

        public static void 发送_不叫()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_不叫) };
            发送数据(sendData);
        }

        public static void 发送_出牌(PokerGroup pg)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_出牌), pg.GetBuffer() };
            发送数据(sendData);
        }

        public static void 发送_Pass()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_Pass) };
            发送数据(sendData);
        }

        public static void 发送_断开()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_断开) };
            发送数据(sendData);
        }

        public static void 发送数据(byte[][] sendData)
        {
            lock (_sync_sendWhisper)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ProxyID, sendData));
            }
        }
        #endregion
    }

    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {

        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (MessageHandler._sync_ReceiveWhisper)
            {
                MessageHandler._receiveWhispers.Enqueue(new KeyValuePair<int, byte[][]>(id, data));
            }
        }

        public void ServiceEnter(int id)
        {
        }

        public void ServiceLeave(int id)
        {
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            Console.Write("Current Service ID List = {");
            foreach (var i in serviceIdList) Console.Write(i + ",");
            Console.Write("}" + Environment.NewLine);
        }

        public void JoinFailed()
        {
        }

        public void ConnectField(Exception ex)
        {
        }

        public bool Ping(byte[][] data)
        {
            //w.WL("Got ping at " + DateTime.Now.ToString());

            //var dt = data[0].ToObject<DataTable>();
            //w.W(dt);

            return true;
        }

        #endregion

        #region IGameLoopHandler Members

        public GameLooper GameLooper { get; set; }

        public void Init()
        {

        }

        public void Process()
        {
        }




        public void SendMessage()
        {
            while (true)
            {
                lock (MessageHandler._sync_sendWhisper)
                {
                    KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[MessageHandler._sendWhispers.Count];
                    MessageHandler._sendWhispers.CopyTo(whispers, 0);
                    MessageHandler._sendWhispers.Clear();
                    foreach (var whisper in whispers)
                    {
                        this.DataCenterProxy.Whisper(whisper.Key, whisper.Value);
                    }
                    Thread.Sleep(1);
                }
            }
        }
        public void Exit()
        {

        }

        #endregion
    }
}
