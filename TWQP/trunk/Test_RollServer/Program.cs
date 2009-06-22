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
            new DataCenterCallback(h);                                    // 连接至 DataCenter 并准备好回调实例
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
    using System.ComponentModel;

    using ConsoleHelper;
    using DAL;

    #endregion

    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        #region 环境变量

        /// <summary>
        /// 用于向控制台输出
        /// </summary>
        private Writer w = Writer.Instance;

        /// <summary>
        /// 指向游戏循环
        /// </summary>
        public GameLooper GameLooper { get; set; }

        /// <summary>
        /// 后台消息发送进程的运行判断标识
        /// </summary>
        private static bool _isSending = true;

        /// <summary>
        /// 用于锁定 收到消息队列
        /// </summary>
        private object _sync_receivedWhispers = new object();
        /// <summary>
        /// 用于锁定 待发消息队列
        /// </summary>
        private object _sync_sendWhispers = new object();

        /// <summary>
        /// 用于锁定 当前玩家列表
        /// </summary>
        private static object _sync_players = new object();

        /// <summary>
        /// 当前玩家列表
        /// </summary>
        private Dictionary<int, Character> _players = new Dictionary<int, Character>();

        /// <summary>
        /// 收到消息队列
        /// </summary>
        private Queue<RollMessage> _receivedWhispers = new Queue<RollMessage>();

        /// <summary>
        /// 待发消息队列
        /// </summary>
        private Queue<RollMessage> _sendWhispers = new Queue<RollMessage>();

        /// <summary>
        /// 当前游戏的状态实例
        /// </summary>
        private RollGameState _state = new RollGameState();

        #endregion

        #region ReceiveWhisper （收到消息后写队列）

        /// <summary>
        /// 过滤并接收消息，存入消息接收队列
        /// </summary>
        public void ReceiveWhisper(int id, byte[][] data)
        {
            // 将收到的数据转为 RollMessage 对象实例
            var msg = new RollMessage
            {
                ID = id,
                RollAction = (RollActions)BitConverter.ToInt32(data[0], 0),
                Data = data.Length > 1 ? data[1] : null
            };

            // 如果消息“合法”
            if (CheckReceiveMessageIsValid(msg))
            {
                // 将 RollMessage 对象实例 插入到接收队列中
                lock (_sync_receivedWhispers)
                {
                    _receivedWhispers.Enqueue(msg);
                }
            }
            else
            {
                // todo: 攻击判定
            }
        }

        /// <summary>
        /// 根据当前游戏的进展，玩家状态来判断当前消息是否“合法”
        /// </summary>
        public bool CheckReceiveMessageIsValid(RollMessage m)
        {
            // 服务刚开始运行
            if (_state.当前阶段 == 0) return false;

            // todo

            return true;
        }

        #endregion

        #region GameLooper Init (初始化，启动消息发送线程）

        public void Init()
        {
            // 声明消息发送循环方法（有消息就发）
            var action = new Action(() =>
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
                        // todo: 改为异步调用？？

                        DataCenterProxy.Whisper(msg.ID,
                            new byte[][] { BitConverter.GetBytes((int)msg.RollAction), msg.Data });
                    }
                    msgs = null;
                    Thread.Sleep(1);
                }
            });

            // 开始执行
            action.BeginInvoke(null, null);
        }

        #endregion

        #region GameLooper Exit （停止后台线程）
        public void Exit()
        {
            _isSending = false;
        }
        #endregion

        #region GameLooper Process （循环处理已收数据，根据业务逻辑产生待发数据）

        public void Process()
        {
            #region 处理当前游戏阶段状态

            if (_state.当前阶段 == 服务阶段枚举.等所有玩家进入)
            {
                int playerCount;
                lock (_sync_players)
                {
                    // 统计 玩家数量（除开正在连接服务的玩家）
                    playerCount = _players.Count(kvp =>
                    {
                        var player = kvp.Value;
                        return player.当前阶段 != 客户端阶段枚举.正在进;
                    });
                }
                // 如果当前不足两个玩家， 则无限等待（ 即等待玩家进入的计数器复位）
                if (playerCount < 2)
                {
                    _state.超时_等所有玩家进入.Current = 0;
                }
                // 如果超时，则进入下一阶段
                else if (_state.超时_等所有玩家进入.IsOvertimed)
                {
                    _state.当前阶段 = 服务阶段枚举.等所有玩家准备;
                    _state.超时_等所有玩家准备.Clear();
                }
            }
            else if (_state.当前阶段 == 服务阶段枚举.等所有玩家准备)
            {

            }
            else if (_state.当前阶段 == 服务阶段枚举.等掷骰子)
            {
            }

            #endregion

            #region 处理收到的消息

            // 将消息从队列移至数组
            RollMessage[] whispers;
            lock (_sync_receivedWhispers)
            {
                whispers = new RollMessage[_receivedWhispers.Count];
                _receivedWhispers.CopyTo(whispers, 0);
                _receivedWhispers.Clear();
            }

            // 循环处理消息
            foreach (var whisper in whispers)
            {
                var id = whisper.ID;
                var clientAction = whisper.RollAction;
                switch (clientAction)
                {
                    case RollActions.C要求进入:
                        处理_C要求进入(id);
                        break;
                    case RollActions.C已进入:
                        处理_C已进入(id);
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

            //// todo: 根据当前游戏的进展，分别判断玩家的超时并处理（踢除或强制状态改变）
            //#region ...
            //lock (_sync_players)
            //{
            //    var counter = GameLooper.Counter;
            //    var removeIds = new List<int>();
            //    foreach (var kvp in _players)
            //    {
            //        var player = kvp.Value;
            //        var id = kvp.Key;
            //        /*
            //        if (player.当前客户端状态 == 客户端状态枚举.正在进)
            //        {
            //            if (player.超时周期_发_能进否 <= counter) removeIds.Add(id);
            //        }
            //        else if (player.客户端状态 == 客户端状态枚举.已发_要求进入)
            //        {
            //            if (player.超时周期_发_要求进入 <= counter) removeIds.Add(id);
            //        }
            //        else if (player.客户端状态 == 客户端状态枚举.已回_已准备好)
            //        {
            //            //if (player.超时周期_回_已准备好 <= counter) removeIds.Add(id);
            //        }
            //        else if (player.客户端状态 == 客户端状态枚举.已回_已掷骰子)
            //        {
            //            //if (player.超时周期_回_已掷骰子 <= counter) removeIds.Add(id);
            //        }
            //        else if (player.客户端状态 == 客户端状态枚举.已回_已看成绩单)
            //        {
            //            if (player.超时周期_回_已看成绩单 <= counter) removeIds.Add(id);
            //        }
            //        */
            //    }
            //    foreach (var id in removeIds) _players.Remove(id);
            //}

            //#endregion
            //// todo: 结合游戏当前阶段，玩家的情况，所经历的时间，对游戏状态进行切换。。。。
            //// todo: 生成玩家应收消息列表
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
        private void 处理_C已进入(int id)
        {
        }
        private void 处理_C已准备好(int id)
        {
        }
        private void 处理_C已投掷(int id)
        {
        }
        #endregion

        #region 往待发消息队列追加数据

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
