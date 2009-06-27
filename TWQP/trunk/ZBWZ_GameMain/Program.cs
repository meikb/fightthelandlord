using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Threading;
using System.ComponentModel;
using ConsoleHelper;
using ZBWZ_DDZ;
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
        private PlayerCollection _player = new PlayerCollection();
        /// <summary>
        /// 游戏服务ID集合
        /// </summary>
        private GameService _gameService = new GameService();

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
            if (id > 199 && id < 300)
            {
                发送_GM_请求服务数据(id);
            }
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
                    case DDZActions.C_准备:
                        处理_C_准备(playerID, whisper.Value);
                        break;
                    case DDZActions.C_出牌:
                        处理_C_出牌(playerID, whisper.Value);
                        break;
                    case DDZActions.C_Pass:
                        处理_C_Pass(playerID, whisper.Value);
                        break;
                    case DDZActions.C_不叫:
                        处理_C_不叫(playerID, whisper.Value);
                        break;
                    case DDZActions.C_叫地主:
                        处理_C_叫地主(playerID, whisper.Value);
                        break;
                    case DDZActions.C_断开:
                        处理_C_断开(playerID, whisper.Value);
                        break;
                    case DDZActions.C_请求桌子数据:
                        处理_C_请求桌子数据(playerID);
                        break;
                    case DDZActions.S_能进入:
                        处理_S_能进入(playerID, whisper.Value);
                        break;
                    case DDZActions.S_不能进入:
                        处理_S_不能进入(playerID, whisper.Value);
                        break;
                    case DDZActions.S_请准备:
                        处理_S_请准备(playerID, whisper.Value);
                        break;
                    case DDZActions.S_请出牌:
                        处理_S_请出牌(playerID, whisper.Value);
                        break;
                    case DDZActions.S_结果:
                        处理_S_结果(playerID, whisper.Value);
                        break;
                    case DDZActions.S_踢出:
                        处理_S_踢出(playerID, whisper.Value);
                        break;
                    case DDZActions.S_返回服务数据:
                        处理_S_返回服务数据(whisper.Key, whisper.Value);
                        break;
                }
            }
        }

        #region 处理消息方法
        private void 处理_C_Pass(int playerID, byte[][] sendData)
        {
            if (_player.ContainsKey(playerID))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[playerID].DestTopID, sendData));
                }
            }
        }

        private void 处理_C_不叫(int playerID, byte[][] sendData)
        {
            if (_player.ContainsKey(playerID))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[playerID].DestTopID, sendData));
                }
            }
        }

        private void 处理_C_叫地主(int playerID, byte[][] sendData)
        {
            if (_player.ContainsKey(playerID))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[playerID].DestTopID, sendData));
                }
            }
        }

        private void 处理_S_返回服务数据(int p, byte[][] whisper)
        {
            _gameService.Add(p, whisper[2].ToObject<int[]>());
        }

        private void 处理_S_踢出(int p,byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_S_结果(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_S_请出牌(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_S_请准备(int p,byte[][] sendData)
        {
            
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_S_不能进入(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_S_能进入(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
                }
            }
        }

        private void 处理_C_请求桌子数据(int p)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(p), BitConverter.GetBytes((int)DDZActions.GM_桌子数据),
                _gameService.ToBinary() };
            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].ProxyID, sendData));
        }

        private void 处理_C_断开(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].DestTopID, sendData));
                }
                _player.Remove(p);
            }
        }

        private void 处理_C_出牌(int p,byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].DestTopID, sendData));
                }
            }
        }

        private void 处理_C_准备(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].DestTopID, sendData));
                }
            }
        }

        private void 处理_C_进入(int p, byte[][] sendData)
        {
            if (_player.ContainsKey(p))
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(_player[p].DestTopID, sendData));
                }
            }
        }

        private void 处理_C_能否进入(int p, byte[][] p_2)
        {
            var selectedServiceID = BitConverter.ToInt32(p_2[2], 0);
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(p), BitConverter.GetBytes((int)DDZActions.C_能否进入) };
            if (selectedServiceID == 0)
            {
                foreach (var service in _gameService)  //随机加入
                {
                    if (service.Value.Length < 3)
                    {
                        lock (_sync_sendWhispers)
                        {
                            _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(service.Key, sendData));
                            var tempPlayer = new DDZCharacter();
                            tempPlayer.DestTopID = service.Key;
                            tempPlayer.ProxyID = p;
                            _player.Add(p, tempPlayer);
                        }
                    }
                }
            }
            else   //选择加入
            {
                lock (_sync_sendWhispers)
                {
                    _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(selectedServiceID, sendData));
                    var tempPlayer = new DDZCharacter();
                    tempPlayer.DestTopID = selectedServiceID;
                    tempPlayer.ProxyID = p;
                    _player.Add(p, tempPlayer);
                }
            }
        }
        #endregion
        #region 发送消息方法
        private void 发送_GM_请求服务数据(int serviceID)
        {
            lock (_sync_sendWhispers)
            {
                byte[][] sendData = new byte[][] { BitConverter.GetBytes(0), BitConverter.GetBytes((int)DDZActions.GM_请求服务数据) };
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(serviceID, sendData));
            }
        }
        #endregion

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

    public class GameService : Dictionary<int,int[]>
    {
        //public int ID { get; set; }
        //public int[] PlayerIDs { get; set; }
        //public GameService(int ID, int[] PlayerIDs)
        //{
        //    this.ID = ID; 
        //    this.PlayerIDs = PlayerIDs;
        //}
        //public GameService(int ID)
        //{
        //    this.ID = ID;
        //}
    }
}