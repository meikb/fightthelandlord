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
            var dt = data[0].ToObject<DataType>();
            object Edata = data[1].ToObject<object>();
            switch (dt)
            {
                case DataType.Action:
                    if ((ActionType)Edata == ActionType.CanIJoinIt)
                    {
                        var dataReturn = _currentStateHander.CanIJoinIt(Players.Count);
                        ActionType temp = dataReturn[1].ToObject<ActionType>();
                        if (temp == ActionType.YouCanJoinIt)
                        {
                            var tempPlayer = new Player(id);
                            tempPlayer.TimeOut = GameLooper.Counter + 5;
                            Players.Add(tempPlayer);
                            w.WL(id + " 准备加入游戏 " + Environment.NewLine);
                        }
                        DataCenterProxy.Whisper(id, data);
                    }
                    if ((ActionType)Edata == ActionType.Join)
                    {
                        if (_currentStateHander.HasThisPlayer(id, Players)) //判断该玩家有没有预约
                        {
                            var tempPlayer = GetPlayerById(id);
                            tempPlayer.Joined = true;
                            tempPlayer.TimeOut = GameLooper.Counter + 30;
                            w.WL(id + " 加入游戏 " + Environment.NewLine);
                        }
                        else
                        {
                            w.WL(id + " 发现非法请求,已拒绝 " + Environment.NewLine);
                        }
                    }
                    if ((ActionType)Edata == ActionType.Ready)
                    {
                        var tempPlayer = GetPlayerById(id);
                        if (tempPlayer != null)
                        {
                            _currentStateHander.PlayerReady(tempPlayer);
                            w.WL(id + " 已准备 " + Environment.NewLine);
                        }
                    }
                    if ((ActionType)Edata == ActionType.Throw)
                    {
                        var tempPlayer = GetPlayerById(id);
                        if (tempPlayer != null)
                        {
                            var numData = _currentStateHander.Throw(tempPlayer);
                            this.DataCenterProxy.Whisper(id, numData);
                            w.WL(id + " 已投掷色子 " + Environment.NewLine);
                        }
                    }
                    break;
                case DataType.UserMessage:
                    Edata = (string)Edata;
                    w.WL(id + " whisper: " + Edata + Environment.NewLine);
                    break;
            }

            //w.WL(id + " whisper: " + dt.ToString() + Environment.NewLine);
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
            if (_currentGameState == GameStates.WatingJoin)
            {
                var h = _currentStateHander as IWatingJoin;
                if (h.JoinSuccess(Players))
                {
                    _currentGameState = GameStates.WatingReady;
                }
                var timeOutPlayer = h.WhoJoinTimeOuted(GameLooper.Counter, Players);
                if (timeOutPlayer != null)
                {
                    Players.Remove(timeOutPlayer);
                }
            }
            if (_currentGameState == GameStates.WatingReady)
            {
                var h = _currentStateHander as IWatingReady;
                if (h.EveryOneIsReady(Players))
                {
                    _currentGameState = GameStates.WatingThrow;
                }
                var timeOutPlayer = h.WhoReadyTimeOuted(GameLooper.Counter, Players);
                if (timeOutPlayer != null)
                {
                    Players.Remove(timeOutPlayer);
                    w.WL("玩家 " + timeOutPlayer.Id.ToString() + " 在规定时间内未准备");
                }
            }
            if (_currentGameState == GameStates.WatingThrow)
            {
                var h = _currentStateHander as IWatingThrow;
                if (h.EveryOneIsThrew(Players))
                {
                    var resultData = h.GetResult(Players);
                    foreach (var onePlayer in Players)
                    {
                        var ScoreData = h.GetScore(onePlayer);
                        DataCenterProxy.Whisper(onePlayer.Id, ScoreData);
                        DataCenterProxy.Whisper(onePlayer.Id, resultData);
                    }
                    _currentGameState = GameStates.WatingReady;
                }
                var timeOutPlayer = h.WhoThrowTimeOuted(GameLooper.Counter, Players);
                if (timeOutPlayer != null)
                {
                    h.Throw(timeOutPlayer);
                    w.WL("玩家 " + timeOutPlayer.Id.ToString() + " 在规定时间内未投掷骰子,服务器自动为其投掷");
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
