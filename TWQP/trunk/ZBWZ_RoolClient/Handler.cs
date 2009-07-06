using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using ConsoleHelper;
using ZBWZ;

namespace ZBWZ_RoolClient
{
    public class Handler : IContactCenterCallbackHandler
    {
        private Writer w = Writer.Instance;
        public object _syncWhispers = new object();
        /// <summary>
        /// 服务器列表
        /// </summary>
        public List<int> _rollServiceIdList = new List<int>();
        /// <summary>
        /// 发出消息列队
        /// </summary>
        Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 收到消息列队
        /// </summary>
        public Queue<KeyValuePair<int, byte[][]>> _receiveWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 游戏状态
        /// </summary>
        public ClientStates clientState { get; set; }
        /// <summary>
        /// 计时器
        /// </summary>
        public long Counter { get; set; }
        /// <summary>
        /// 玩家
        /// </summary>
        public Character player;
        /// <summary>
        /// 远程服务ID
        /// </summary>
        public int ServerID;

        public Handler(int PlayerId)
        {
            this.ServiceID = PlayerId;
        }

        #region IContactCenterCallbackHandler Members
        /// <summary>
        /// 玩家ID
        /// </summary>
        public int ServiceID { get; set; }
        public ContactCenterProxy ContactCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {
            w.WL(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (_syncWhispers)
            {
                //将接收到的数据加入到列队
                _receiveWhispers.Enqueue(new KeyValuePair<int, byte[][]>(id, data));
            }
        }

        public void ServiceEnter(int id)
        {
            if (id > 100)
            {
                lock (_syncWhispers)
                {
                    if (!_rollServiceIdList.Contains(id)) _rollServiceIdList.Add(id);
                    // todo
                }
            }
            w.WL("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            if (id > 100)
            {
                lock (_syncWhispers)
                {
                    if (_rollServiceIdList.Contains(id)) _rollServiceIdList.Remove(id);
                    // todo
                }
            }
            w.WL("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            foreach (var id in serviceIdList)
                if (id > 100) _rollServiceIdList.Add(id);

            //w.WL("已于" + DateTime.Now.ToString() + " 连入联络中心");
            if (_rollServiceIdList.Count > 0)
            {
                //w.W("发现 Roll 游戏服务器：");
                //w.W("请输入服务器ID加入相应服务器" + Environment.NewLine);
                //w.W<int>(_rollServiceIdList);
                //w.WL();
            }
            else
            {
               // w.W("未发现任何 Roll 游戏服务器！");
            }
        }

        public void JoinFailed()
        {
            w.WL("Error: service id " + this.ServiceID + " already exist!");
        }

        public void ConnectField(Exception ex)
        {
            w.WL("Error: Cannot connect to service!");
            w.WL(ex.Message);
        }

        public bool Ping(byte[][] data)
        {
            //w.WL("Got ping at " + DateTime.Now.ToString());

            //var dt = data[0].ToObject<DataTable>();
            //w.W(dt);

            return true;
        }

        #endregion

//        #region IGameLoopHandler Members

//        public GameLooper GameLooper { get; set; }

//        public void Init()
//        {
//            w.WL(@"
//游戏开始运行.
//类型：RollGame Client
//编号：{0}
//时间：{1}
//", this.ServiceID, DateTime.Now);
//        }

//        public void Process()
//        {

//        }

//        public void Exit()
//        {
//            w.WE();
//        }

//        #endregion

        #region 发出消息
        public void 发出_能进否()
        {
            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ServerID, new byte[][] { BitConverter.GetBytes((int)RollActions.C_能否进入) }));
        }

        public void 发出_进入()
        {
            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ServerID, new byte[][] { BitConverter.GetBytes((int)RollActions.C_进入) }));
        }

        public void 发出_准备()
        {
            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ServerID, new byte[][] { BitConverter.GetBytes((int)RollActions.C_准备) }));
        }

        public void 发出_投掷()
        {
            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ServerID, new byte[][] { BitConverter.GetBytes((int)RollActions.C_投掷) }));
        }

        public void 发出_所有消息()
        {
            KeyValuePair<int, byte[][]>[]  whispers = new KeyValuePair<int, byte[][]>[_sendWhispers.Count];
            _sendWhispers.CopyTo(whispers, 0);
            _sendWhispers.Clear();
            foreach (var whisper in whispers) ContactCenterProxy.Whisper(ServerID, whisper.Value);
        }
        #endregion
        #region 处理超时
        public void 处理超时()
        {
            if (Counter >= player.超时_进入超时 && player.clientState == ClientStates.已发_能进否)
            {
                clientState = ClientStates.收到_断开;
            }
            if (Counter >= player.超时_准备超时 && player.clientState == ClientStates.已发_要求进入)
            {
                clientState = ClientStates.收到_断开;
            }
            if (Counter >= player.超时_投掷超时 && player.clientState == ClientStates.已发_已准备好)
            {
                clientState = ClientStates.收到_断开;
            }
        }
        #endregion

        #region 处理消息
        public void 处理_能够进入()
        {
            发出_进入();
            clientState = ClientStates.已发_要求进入;
        }
        public void 处理_不能进入()
        {
            clientState = ClientStates.收到_断开;
        }
        public void 处理_请准备()
        {
            clientState = ClientStates.收到_请准备;
        }
        public void 处理_请投掷()
        {
            clientState = ClientStates.收到_请投掷;
        }
        public void 处理_点数(int Score)
        {
            player.Num = Score;
        }
        /// <summary>
        /// 处理消息:结果
        /// </summary>
        /// <param name="dataResult">赢家ID列表</param>
        /// <returns>true表示自己是赢家,false表示自己是输家</returns>
        public bool 处理_结果(int[] dataResult)
        {
            clientState = ClientStates.收到_请准备;
            return dataResult.Contains<int>(ServiceID);
        }
        public void 处理_踢出()
        {
            clientState = ClientStates.收到_断开;
        }
        #endregion

    }
}
