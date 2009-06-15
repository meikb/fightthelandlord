using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Threading;
using ConsoleHelper;
using Extensions;
using ZBWZ;
using DAL;

namespace ZBWZ_RollServer
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new Handler(id);
            Console.CursorVisible = false;
            new DataCenterCallback(h);  // 连接至 DataCenter 并准备好回调实例
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
        /// 玩家集合
        /// </summary>
        private List<Player> Players = new List<Player>();
        /// <summary>
        /// 游戏状态
        /// </summary>
        GameStates _currentGameState = GameStates.WatingJoin;
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

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }
        private static object _sync_players = new object();
        private static object _sync_whispers = new object();
        /// <summary>
        /// 玩家列表
        /// </summary>
        private static Dictionary<int, KeyValuePair<int,Character>> _players = new Dictionary<int,KeyValuePair<int,Character>>();
        /// <summary>
        /// 收到消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _receivedWhispers = new Queue<KeyValuePair<int,byte[][]>>();
        /// <summary>
        /// 发送消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();

        /// <summary>
        /// 通过ID获取玩家
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>玩家</returns>
        public Player GetPlayerById(int id)
        {
            foreach (var onePlayer in Players)
            {
                if (onePlayer.Id == id)
                {
                    return onePlayer;
                }
            }
            return null;
        }

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
类型：RollGame Server
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
        }

        public void Process()
        {
            #region 处理消息
            KeyValuePair<int, byte[][]>[] whispers;
            lock (_sync_whispers)
            {
                whispers = new KeyValuePair<int, byte[][]>[_receivedWhispers.Count];
                _receivedWhispers.CopyTo(whispers, 0);
                _receivedWhispers.Clear();
            }
            foreach (var whisper in whispers)
            {
                var id = whisper.Key;
                var clientAction = (ClientActions)BitConverter.ToInt32(whisper.Value[0], 0);
                switch (clientAction)
                {
                    case ClientActions.发_能进否:
                        收到消息_发_能进否(id);
                        break;
                    case ClientActions.发_要求进入:
                        收到消息_发_要求进入(id);
                        break;
                    case ClientActions.回_已准备好:
                        收到消息_回_已准备好(id);
                        break;
                    case ClientActions.回_已掷骰子:
                        收到消息_回_已掷骰子(id);
                        break;
                    case ClientActions.回_已看成绩单:
                        收到消息_回_已看成绩单(id);
                        break;
                }

                #region 处理超时

                // 根据当前游戏的进展，分别判断玩家的超时并处理（踢除或强制状态改变）
                lock (_sync_players)
                {
                    var counter = GameLooper.Counter;
                    var removeIds = new List<int>();
                    foreach (var kvp in _players)
                    {
                        var player = kvp.Value;
                        var id = kvp.Key;
                        if (player.客户端状态 == 客户端状态枚举.已发_能进否)
                        {
                            if (player.超时周期_发_能进否 <= counter) removeIds.Add(id);
                        }
                        else if (player.客户端状态 == 客户端状态枚举.已发_要求进入)
                        {
                            if (player.超时周期_发_要求进入 <= counter) removeIds.Add(id);
                        }
                        else if (player.客户端状态 == 客户端状态枚举.已回_已准备好)
                        {
                            //if (player.超时周期_回_已准备好 <= counter) removeIds.Add(id);
                        }
                        else if (player.客户端状态 == 客户端状态枚举.已回_已掷骰子)
                        {
                            //if (player.超时周期_回_已掷骰子 <= counter) removeIds.Add(id);
                        }
                        else if (player.客户端状态 == 客户端状态枚举.已回_已看成绩单)
                        {
                            if (player.超时周期_回_已看成绩单 <= counter) removeIds.Add(id);
                        }
                    }
                    foreach (var id in removeIds) _players.Remove(id);
                }

                #endregion
            }
            #endregion


        }

        #region 收到消息
        private void 收到消息_发_能进否(int id)
        {
            // todo: check...
            // 对于　能进否 来说，有如下条件：
            // 不超出游戏最大上限人数

            // 把玩家加入列表
            lock (_sync_players)
            {
                if (!_players.ContainsKey(id))
                {
                    var player = new Character();
                    //占位
                    _players.Add(id, player);
                    //十秒未发送 要求进入,就删之
                    player.超时周期_发_能进否 = GameLooper.Counter + 10;

                }
                else
                {
                    // todo: 重复的 id 进入
                }
            }
        }
        private void 收到消息_发_要求进入(int id)
        {
            // 对于　要求进入 来说，有如下条件：
            // 玩家处于发起　能进否　的询问状态且未超时的

            // 先看看列表里有没有玩家
            lock (_sync_players)
            {
                if (_players.ContainsKey(id))
                {
                    var player = _players[id].Value;
                    if (player.客户端状态 == 客户端状态枚举.已发_能进否)
                    {
                        // 令 player 进
                        player.客户端状态 = 客户端状态枚举.已发_要求进入;
                        // set 超时
                        player.超时周期_发_要求进入 = GameLooper.Counter + 30;
                        发出消息_回_请进入(id);
                    }
                }
                else
                {
                    发出消息_回_不能进(id);
                }
            }
        }
        private void 收到消息_回_已准备好(int id)
        {
            lock (_sync_players)
            {
                if (_players.ContainsKey(id))
                {
                    var player = _players[id].Value;
                    if (player.客户端状态 == 客户端状态枚举.已发_要求进入)
                    {
                        //让 player 准备
                        player.客户端状态 = 客户端状态枚举.已回_已准备好;
                        // set 超时
                    }
                }
            }
        }
        private void 收到消息_回_已掷骰子(int id)
        {
            lock (_sync_players)
            {
                if (_players.ContainsKey(id))
                {
                    var player = _players[id].Value;
                    if (player.客户端状态 == 客户端状态枚举.已回_已准备好)
                    {
                        //让 player 投掷骰子
                        player.客户端状态 = 客户端状态枚举.已回_已掷骰子;
                        
                        
                    }
                }
            }
        }
        private void 收到消息_回_已看成绩单(int id)
        {
        }
        #endregion
        #region 发出消息
        private void 发出消息_回_能进(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.回_能进) });
        }
        private void 发出消息_回_不能进(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.回_不能进) });
        }
        private void 发出消息_回_请进入(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.回_请进入) });
        }
        private void 发出消息_回_不能进入(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.回_不能进入) });
        }
        private void 发出消息_发_请准备(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.发_请准备) });
        }
        private void 发出消息_发_请掷骰子(int id)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.发_请掷骰子) });
        }
        private void 发出消息_发_请看成绩单(int id, byte[] data)
        {
            this.DataCenterProxy.Whisper(id, new byte[][] { BitConverter.GetBytes((int)ServiceActions.发_请看成绩单), data });
        }
        #endregion



        public void Exit()
        {
            w.WE();
        }

        #endregion
    }

    [Serializable]
    public class Character : OO.User_Character
    {
        public 客户端状态枚举 客户端状态;
        public long 超时周期_发_要求进入;
        public long 超时周期_回_已准备好;
        public long 超时周期_回_已掷骰子;
        public long 超时周期_回_已看成绩单;
        public int 获胜次数;
    }

    public class Message
    {
        int Id;
        byte[][] data;
    }

    public class ReceiveMessage : Message
    {
        public ClientActions ClientAction;
    }
    public class SendMessage : Message
    {
        public ServiceActions ServiceAction;
    }


}
