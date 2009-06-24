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

namespace ZBWZ_GameMain
{
    class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var h = new Handler(150);  //大厅暂为ID为150
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
        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }
        private static object _sync_whispers = new object();
        private static object _sync_sendWhispers = new object();
        /// <summary>
        /// 收到消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _receivedWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 发送消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 玩家集合
        /// </summary>
        private PlayerCollections _player = new PlayerCollections();
        /// <summary>
        /// 游戏服务ID集合
        /// </summary>
        private List<int> GameServiceIDs = new List<int>();

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
            foreach (var i in serviceIdList) Console.Write(i + ",");
            Console.Write("}" + Environment.NewLine);
            foreach (var i in serviceIdList)
            {
                if (i > 199 && i < 300)
                {
                    发送_GM_请求服务数据(i);
                    GameServiceIDs.Add(i);
                }
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

        #region IGameLoopHandler Members

        public GameLooper GameLooper { get; set; }

        public void Init()
        {
            w.WL(@"
服务开始运行.
类型：FightTheLandLordGame GameMain
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
        }

        public void Process()
        {
            KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[_receivedWhispers.Count];
            lock (_sync_whispers)
            {
                _receivedWhispers.CopyTo(whispers, 0);
                _receivedWhispers.Clear();
            }
            foreach (var whisper in whispers)
            {
                var playerID = BitConverter.ToInt32(whisper.Value[0], 0);
                var action = (DDZActions)BitConverter.ToInt32(whisper.Value[1], 0);
                switch (action)
                {
                    case DDZActions.C_能否进入:
                        处理_C_能否进入(playerID, whisper.Value);
                        break;
                    case DDZActions.C_进入:
                        处理_C_进入(playerID, whisper.Value);
                        break;
                    case DDZActions.C_选择桌子:
                        处理_C_选择桌子(playerID, whisper.Value);
                        break;
                    case DDZActions.C_准备:
                        处理_C_准备(playerID, whisper.Value);
                        break;
                    case DDZActions.C_出牌:
                        处理_C_出牌(playerID, whisper.Value);
                        break;
                    case DDZActions.C_断开:
                        处理_C_断开(playerID, whisper.Value);
                        break;
                    case DDZActions.C_请求桌子数据:
                        处理_C_请求桌子数据(playerID, whisper.Value);
                        break;
                    case DDZActions.S_能进入:
                        处理_S_能进入(playerID, whisper.Value);
                        break;
                    case DDZActions.S_不能进入:
                        处理_S_不能进入(playerID, whisper.Value);
                        break;
                    case DDZActions.S_坐下:
                        处理_S_坐下(playerID, whisper.Value);
                        break;
                    case DDZActions.S_请准备:
                        处理_S_请准备(playerID, whisper.Value);
                        break;
                    case DDZActions.S_请出牌:
                        处理_S_请出牌(playerID, whisper.Value);
                        break;
                    case DDZActions.S_点数:
                        处理_S_点数(playerID, whisper.Value);
                        break;
                    case DDZActions.S_结果:
                        处理_S_结果(playerID, whisper.Value);
                        break;
                    case DDZActions.S_踢出:
                        处理_S_踢出(playerID, whisper.Value);
                        break;
                    case DDZActions.S_返回服务数据:
                        处理_S_返回服务数据(playerID, whisper.Value);
                        break;
                }
            }
        }

        private void 处理_S_返回服务数据(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_断开(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }
        //todo 实现处理数据的一系列方法
        private void 处理_S_桌子数据(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_踢出(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_结果(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_点数(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_请出牌(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_请准备(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_坐下(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_不能进入(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_S_能进入(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_请求桌子数据(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_出牌(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_准备(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_选择桌子(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_进入(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }

        private void 处理_C_能否进入(int playerID, byte[][] p)
        {
            throw new NotImplementedException();
        }


        private void 发送_GM_请求服务数据(int serviceID)
        {

        }

        public void 发送信息(int ID, byte[][] data)
        {
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(ID, data));
            }
        }

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