namespace Test_RollServer
{
    using System;
    using ConsoleHelper;

    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new RollGame.Handler(id);
            new DataCenterCallback(h);  // 连接至 DataCenter 并准备好回调实例
            new GameLooper(h).Loop();   // 创建游戏循环并运行
        }
    }
}


namespace RollGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Timers;
    using System.Threading;
    using ConsoleHelper;
    using DAL;


    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        private Writer w = Writer.Instance;
        public GameLooper GameLooper { get; set; }
        private static object _sync_players = new object();
        private static object _sync_whispers = new object();
        private static Dictionary<int, Character> _players = new Dictionary<int, Character>();
        private static Queue<KeyValuePair<int, byte[][]>> _receivedWhispers = new Queue<KeyValuePair<int, byte[][]>>();

        #region ReceiveWhisper

        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (_sync_whispers)
            {
                _receivedWhispers.Enqueue(new KeyValuePair<int, byte[][]>(id, data));
            }
        }

        #endregion

        #region GameLooper Init
        public void Init()
        {
            w.WL(@"
服务开始运行.
类型：RollGame Server
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
        }
        #endregion

        #region GameLooper Process

        public void Process()
        {
            KeyValuePair<int, byte[][]>[] whispers;
            lock (_sync_whispers)
            {
                whispers = new KeyValuePair<int,byte[][]>[_receivedWhispers.Count];
                _receivedWhispers.CopyTo(whispers, 0);
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
            }
        }

        #region 收到消息
        private void 收到消息_发_能进否(int id)
        {
            // todo: check...
            // 把玩家加入列表
            lock (_sync_players)
            {
                if (!_players.ContainsKey(id)) _players.Add(id, new Character());
                else
                {
                    // todo: 重复的 id 进入
                }
            }
        }
        private void 收到消息_发_要求进入(int id)
        {
            // 先看看列表里有没有玩家
            lock (_sync_players)
            {
                if (_players.ContainsKey(id))
                {
                    var player = _players[id];
                    // ...
                }
                else
                {
                    发出消息_回_不能进(id);
                }
            }
        }
        private void 收到消息_回_已准备好(int id)
        {
        }
        private void 收到消息_回_已掷骰子(int id)
        {
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

        #endregion

        #region GameLooper Exit
        public void Exit()
        {
        }
        #endregion

        #region 暂时不用管这些

        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion


        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {
        }

        public void ServiceEnter(int id)
        {
        }

        public void ServiceLeave(int id)
        {
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
        }

        public void JoinFailed()
        {
        }

        public void ConnectField(Exception ex)
        {
            w.WL("Error: Cannot connect to service!");
            w.WL(ex.Message);
        }

        public bool Ping(byte[][] data)
        {
            return true;
        }

        #endregion
    }

    #region 服务中用到的相关类定义

    public class Message
    {
        public int ID;
        public byte[] Data;
    }

    public class ReceiveMessage : Message
    {
        public ClientActions ClientAction;
    }

    public class SendMessage : Message
    {
        public ServiceActions ServiceAction;
    }


    [Serializable]
    public class Character : OO.User_Character
    {
        public PlayerStates PlayerState;
        public long AskExpireCount;
        public long JoinExpireCount;
        public long ReadyExpireCount;
        public long RollExpireCount;
        public int Score;
        public int Point;
    }
    public enum GameStates
    {
        Ready, Play
    }
    public enum PlayerStates
    {
        Ask, Join, Ready, Roll
    }

    public enum ServiceActions
    {
        // Client Action : 发_能进否
        回_能进,
        回_不能进,

        // Client Action : 发_要求进入
        回_请进入,
        回_不能进入,

        发_请准备,

        发_请掷骰子,

        发_请看成绩单     // 带数据报表
    }

    public enum ClientActions
    {
        发_能进否,

        发_要求进入,

        // Service Action : 发_请准备
        回_已准备好,

        // Service Action : 发_请掷骰子
        回_已掷骰子,

        // Service Action : 发_请看成绩单
        回_已看成绩单
    }

    #endregion
}
