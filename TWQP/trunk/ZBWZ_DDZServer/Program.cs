using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Threading;
using System.ComponentModel;
using ConsoleHelper;
using ZBWZ;
using DAL;

namespace ZBWZ_DDZServer
{
    class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new Handler(id);
            Console.CursorVisible = false;
            new DataCenterCallback(h);  // 连接至 DataCenter 并准备好回调实例
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(h.SendMessage);
            bw.RunWorkerAsync();
            var gameLooper = new GameLooper(h);   // 创建游戏循环并运行
            gameLooper.IsSpeedLimitMode = true; //限速循环
            gameLooper.LoopDurationLimit = 1000; //每次循环耗时1秒
            gameLooper.Loop();
        }
    }

    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        private Writer w = Writer.Instance;
        /// <summary>
        /// 状态处理程序
        /// </summary>
        StateHandler _currentStateHander = new StateHandler();
        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion

        #region IDataCenterCallbackHandler Members
        /// <summary>
        /// 自己的ID
        /// </summary>
        public int ServiceID { get; set; }
        /// <summary>
        /// 占用服务的大厅ID
        /// </summary>
        public int GameMainID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }
        private static object _sync_players = new object();
        private static object _sync_whispers = new object();
        private static object _sync_sendWhispers = new object();
        /// <summary>
        /// 玩家列表
        /// </summary>
        private static PlayerCollections _players = new PlayerCollections();
        /// <summary>
        /// 收到消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _receivedWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 发送消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 服务流程状态
        /// </summary>
        private static ServiceStates serviceState = ServiceStates.等待客户端进入;

        public void Receive(int id, byte[][] data)
        {
            w.WL(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (_sync_whispers)
            {
                _receivedWhispers.Enqueue(new KeyValuePair<int, byte[][]>(id, data));
            }
        }

        public void ServiceEnter(int id)
        {
            w.WL("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            w.WL("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            w.WL("Connected at " + DateTime.Now.ToString() + " with service id " + this.ServiceID + Environment.NewLine);
            Console.Write("Current Service ID List = {");
            foreach (var serviceID in serviceIdList) Console.Write(serviceID + ",");
            Console.Write("}" + Environment.NewLine);
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

        #region IGameLoopHandler Members

        public GameLooper GameLooper { get; set; }

        public void Init()
        {
            w.WL(@"
服务开始运行.
类型：FightTheLandLordGame Server
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
            _currentStateHander.AmountPlayer = 3;
        }

        public void Process()
        {
            KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[_receivedWhispers.Count];
            lock (_sync_whispers)
            {
                _sendWhispers.CopyTo(whispers, 0);
                _sendWhispers.Clear();
            }
            foreach (var whisper in whispers)
            {
                var playerid = BitConverter.ToInt32(whisper.Value[0],0);
                switch ((DDZActions)BitConverter.ToInt32(whisper.Value[1],0))
                {
                    case DDZActions.C_能否进入:
                        处理_能否进入(playerid);
                        break;
                    case DDZActions.C_进入:
                        处理_进入(playerid);
                        break;
                    case DDZActions.C_准备:
                        处理_准备(playerid);
                        break;
                    case DDZActions.C_出牌:
                        处理_出牌(playerid, whisper.Value);
                        break;
                    case DDZActions.GM_请求服务数据:
                        处理_GM_请求服务数据();
                        break;
                }
            }
            #region 游戏状态管理
            if (serviceState == ServiceStates.等待客户端进入)
            {
                var h = _currentStateHander as IWatingJoin;
            }
            else if (serviceState == ServiceStates.等待客户端准备好)
            {
                var h = _currentStateHander as IWatingReady;
            }
            else if (serviceState == ServiceStates.正在游戏)
            {

            }
            #region
        }
        #region 处理消息
        private void 处理_GM_请求服务数据()
        {
            发出_服务数据();
        }

        private void 处理_出牌(int playerid, byte[][] p)
        {
            //todo 再写游戏逻辑和流程
        }

        private void 处理_准备(int playerid)
        {
            if (_players.ContainsKey(playerid))
            {
                _players[playerid].clientState = ClientStates.已发_已准备好;
            }
        }

        private void 处理_进入(int playerid)
        {
            if (_players.ContainsKey(playerid))
            {
                _players[playerid].clientState = ClientStates.已发_要求进入;
                发出_请准备(playerid);
            }
        }

        private void 处理_能否进入(int playerid)
        {
            if (_currentStateHander.CanIJoinIt(_players.Count))
            {
                var tempPlayer = new Character();
                tempPlayer.超时_进入超时 = GameLooper.Counter + 10;
                发出_能进入(playerid);

            }
            else
            {
                发出_不能进入(playerid);
            }
        }
        #endregion
        #region 发出消息
        private void 发出_请准备(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_请准备) };
            发出消息(sendData);
        }

        private void 发出_不能进入(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_不能进入) };
            发出消息(sendData);
        }

        private void 发出_能进入(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_能进入) };
            发出消息(sendData);
        }



        private void 发出_服务数据()
        {
            List<int> playerIdsList = new List<int>();
            foreach (var tempPlayer in _players)
            {
                playerIdsList.Add(tempPlayer.Key);
            }
            int[] playerIDs = playerIdsList.ToArray();
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(0),
                BitConverter.GetBytes((int)DDZActions.S_返回服务数据),
                playerIDs.ToBinary() };
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(GameMainID, sendData));
            }
        }
        #endregion
        /// <summary>
        /// 发送消息给绑定的大厅
        /// </summary>
        /// <param name="sendData">消息</param>
        private void 发出消息(byte[][] sendData)
        {
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(GameMainID, sendData));
            }
        }
        /// <summary>
        /// 发送消息给指定的ID
        /// </summary>
        /// <param name="sendTo">指定的ID</param>
        /// <param name="sendData">消息</param>
        private void 发出消息(int sendTo, byte[][] sendData)
        {
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(sendTo, sendData));
            }
        }
        //todo 实现Server端数据处理
        public void SendMessage(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                lock (_sync_sendWhispers)
                {
                    KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[_sendWhispers.Count];
                    _sendWhispers.CopyTo(whispers, 0);
                    _sendWhispers.Clear();
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
            w.WE();
        }

        #endregion
    }
}
