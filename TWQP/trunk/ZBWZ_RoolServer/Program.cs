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
            }
            #endregion
        }

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
        public long 超时周期_发_能进否;
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
