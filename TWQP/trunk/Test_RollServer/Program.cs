namespace Test_RollServer
{
    using System;
    using ConsoleHelper;
    using System.ComponentModel;

    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new RollGame.Handler(id);
            new DataCenterCallback(h);                                      // 连接至 DataCenter 并准备好回调实例
            new GameLooper(h) { LoopDurationLimit = 1000 }.Loop();        // 创建游戏循环并运行
        }
    }
}


namespace RollGame
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Timers;
    using System.Threading;
    using ConsoleHelper;
    using DAL;
    using System.ComponentModel;
    #endregion

    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        #region 环境变量

        private Writer w = Writer.Instance;
        public GameLooper GameLooper { get; set; }
        private static bool _isSending = true;
        private static object _sync_players = new object();
        private static object _sync_receivedWhispers = new object();
        private static object _sync_sendWhispers = new object();
        private static Dictionary<int, Character> _players = new Dictionary<int, Character>();
        private static Queue<RollMessage> _receivedWhispers = new Queue<RollMessage>();
        private static Queue<RollMessage> _sendWhispers = new Queue<RollMessage>();

        #endregion

        #region ReceiveWhisper （收到消息后写队列）

        /// <summary>
        /// 过滤并接收消息，存入消息接收队列
        /// </summary>
        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (_sync_receivedWhispers)
            {
                var msg = new RollMessage
                {
                    ID = id,
                    RollAction = (RollActions)BitConverter.ToInt32(data[0], 0),
                    Data = data.Length > 1 ? data[1] : null
                };

                // todo: 检查当前 msg 是否有效（根据当前游戏进展，以及玩家的状态检查）
                // 根据 id 定位玩家，如果未找到，则当前允许的是 请求进入指令
                // 否则允许的是 “当前允许收到的客户端消息列表”

                _receivedWhispers.Enqueue(msg);
            }
        }

        #endregion

        #region GameLooper Init (初始化消息发送线程）
        public void Init()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, ea) =>
            {
                while (_isSending)
                {
                    RollMessage[] msgs;
                    lock (_sync_sendWhispers)
                    {
                        msgs = new RollMessage[_sendWhispers.Count];
                        _sendWhispers.CopyTo(msgs, 0);
                        _sendWhispers.Clear();
                    }
                    foreach (var msg in msgs)
                    {
                        // todo: async call Whisper

                        DataCenterProxy.Whisper(msg.ID,
                            new byte[][] { BitConverter.GetBytes((int)msg.RollAction), msg.Data });
                    }
                    msgs = null;
                    Thread.Sleep(1);
                }
            };
            bw.RunWorkerAsync();
        }

        #endregion

        #region GameLooper Exit （停止后台线程）
        public void Exit()
        {
            _isSending = false;
        }
        #endregion

        #region GameLooper Process （每秒处理一次业务逻辑）

        public void Process()
        {
            #region 处理收到的消息

            // 从队列读取消息
            RollMessage[] whispers;
            lock (_sync_receivedWhispers)
            {
                whispers = new RollMessage[_receivedWhispers.Count];
                _receivedWhispers.CopyTo(whispers, 0);
                _receivedWhispers.Clear();
            }

            // 处理
            foreach (var whisper in whispers)
            {
                var id = whisper.ID;
                var clientAction = whisper.RollAction;
                switch (clientAction)
                {
                    case RollActions.C要求进入:
                        处理_C要求进入(id);
                        break;
                    case RollActions.C已准备好:
                        处理_C已准备好(id);
                        break;
                    case RollActions.C已投掷:
                        处理_C已投掷(id);
                        break;
                }
            }

            #endregion

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
                    /*
                    if (player.当前客户端状态 == 客户端状态枚举.正在进)
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
                    */
                }
                foreach (var id in removeIds) _players.Remove(id);
            }

            #endregion

            #region 生成玩家应收消息列表

            // todo

            #endregion
        }

        #region 处理收到的消息

        private void 处理_C要求进入(int id)
        {
            // 对于　要求进入 来说，有如下条件：
            // 不超出游戏最大上限人数
            // 玩家于列表中不存在，玩家未存在于别的游戏服务（将来会用到）
            lock (_sync_players)
            {
                if (_players.ContainsKey(id))
                {
                    var player = _players[id];
                    /*
                    if (player.客户端状态 == 客户端状态枚举.已发_能进否)
                    {
                        // 令 player 进
                        player.客户端状态 = 客户端状态枚举.已发_要求进入;
                        // set 超时
                        发出消息_回_请进入(id);
                    }
                     */
                }
                else
                {
                    发出_S不能进入(id);
                }
            }
        }
        private void 处理_C已准备好(int id)
        {
        }
        private void 处理_C已投掷(int id)
        {
        }
        #endregion

        #region 发出消息
        private void 发出_S请进入(int id)
        {
            _sendWhispers.Enqueue(new RollMessage { ID = id, RollAction = RollActions.S请进入 });
        }
        private void 发出_S不能进入(int id)
        {
            _sendWhispers.Enqueue(new RollMessage { ID = id, RollAction = RollActions.S不能进入 });
        }
        private void 发出_S请准备(int id)
        {
            _sendWhispers.Enqueue(new RollMessage { ID = id, RollAction = RollActions.S请准备 });
        }
        private void 发出_S请投掷(int id)
        {
            _sendWhispers.Enqueue(new RollMessage { ID = id, RollAction = RollActions.S请投掷 });
        }
        private void 发出_S请看成绩(int id, byte[] data)
        {
            _sendWhispers.Enqueue(new RollMessage { ID = id, RollAction = RollActions.S请看成绩 });   // todo: , data = ...
        }
        #endregion

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

}
