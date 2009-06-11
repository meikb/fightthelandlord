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
            new GameLooper(h).Loop();   // 创建游戏循环并运行
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
        /// 最大玩家数量
        /// </summary>
        private readonly int PlayersAmount = 3;
        /// <summary>
        /// 每局分数
        /// </summary>
        private readonly int RoundScore = 10;
        /// <summary>
        /// 游戏是否已经开始
        /// </summary>
        private bool IsStart { get; set; }

        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

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
                        if (Players.Count < PlayersAmount)
                        {
                            var tempPlayer = new Player(id);
                            tempPlayer.TimeOut.Interval = 5000;
                            tempPlayer.TimeOut.Elapsed += (sender1, ea1) =>
                            {
                                if (!tempPlayer.IsJoin)
                                {
                                    tempPlayer.IsDead = true;
                                    tempPlayer.TimeOut.Stop();
                                }
                            };  //如果该用户5秒钟未加入游戏,则干掉该用户.
                            tempPlayer.TimeOut.Start();
                            Players.Add(tempPlayer); //给该用户占位.
                            byte[][] dataJoinedSuccess = { DataType.Action.ToBinary(), ActionType.YouCanJoinIt.ToBinary() };
                            this.DataCenterProxy.Whisper(id, dataJoinedSuccess); //通知该用户可以加入游戏.
                            w.WL(id + " 准备加入游戏 " + Environment.NewLine);
                        }
                        else
                        {
                            byte[][] dataReject = { DataType.Action.ToBinary(), ActionType.YouCanNotJoinIt.ToBinary() };
                            this.DataCenterProxy.Whisper(id, dataReject);  //拒绝掉该用户加入游戏的请求
                            w.WL(id + " 尝试进入,但服务器人数已满无法进入 " + Environment.NewLine);
                        }
                    }
                    if ((ActionType)Edata == ActionType.Join)
                    {
                        var PlayerIsExist = false;
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Id == id)
                            {
                                onePlayer.IsJoin = true;  //该用户已加入
                                PlayerIsExist = true;
                            }
                            w.WL(id + " 加入游戏 " + Environment.NewLine);
                        }
                        if (!PlayerIsExist)
                        {
                            byte[][] dataReject = { DataType.Action.ToBinary(), ActionType.YouCanNotJoinIt.ToBinary() };
                            this.DataCenterProxy.Whisper(id, dataReject);
                            w.WL(id + " 发现非法请求,已拒绝 " + Environment.NewLine);
                        }  //拒绝掉该用户加入游戏的请求 
                    }
                    if ((ActionType)Edata == ActionType.Ready)
                    {
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Id == id)
                            {
                                onePlayer.IsReady = true;
                            }
                        }
                        w.WL(id + " 已准备 " + Environment.NewLine);
                    }
                    if ((ActionType)Edata == ActionType.Throw)
                    {
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Id == id)
                            {
                                onePlayer.Num = new Random().Next(1, 7);
                                onePlayer.IsThrew = true;
                            }
                        }
                        w.WL(id + " 已投掷色子 " + Environment.NewLine);
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
            var ThrewPlayers = 0;
            var ReadiedPlayers = 0;
            w.W(60, 0, true, ConsoleColor.White, ConsoleColor.Black, DateTime.Now.ToString());
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].IsDead)
                {
                    byte[][] dataOut = { DataType.Action.ToBinary(), ActionType.Out.ToBinary() };
                    this.DataCenterProxy.Whisper(Players[i].Id, dataOut);  //通知玩家被踢
                    w.WL("玩家" + Players[i].Id + "在规定时间内(15秒)没有准备或者由于网络原因被踢" + Environment.NewLine);
                    Players.Remove(Players[i]);  //移除挂掉的玩家
                    break;
                }
            }
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].IsJoin)
                {
                    Players[i].IsJoin = false;
                    Players[i].ThrowTimeOuted = false;
                    Players[i].TimeOut.Interval = 15000;  //如果玩家15秒未准备就干掉玩家
                    Players[i].TimeOut.Elapsed += (sender1, ea1) =>
                    {
                        try
                        {
                            if (!Players[i].IsReady)
                            {
                                Players[i].IsDead = true;
                                Players[i].TimeOut.Stop();
                            }
                        }
                        catch
                        {
                        }
                    };
                    Players[i].TimeOut.Start();
                    byte[][] dataJoinedSuccess = { DataType.Action.ToBinary(), ActionType.JoinedSuccess.ToBinary() };
                    this.DataCenterProxy.Whisper(Players[i].Id, dataJoinedSuccess);  //通知玩家加入游戏成功
                    w.WL("玩家" + Players[i].Id + "成功加入游戏,服务器已发送消息让其准备,如果该玩家15秒内未准备,服务器将踢掉该玩家" + Environment.NewLine);
                }
                if (Players[i].IsReady)
                {
                    ReadiedPlayers++;
                }
                if (Players[i].IsThrew)
                {
                    Players[i].IsThrew = false;
                    ThrewPlayers++;
                    byte[][] dataThrewNum = { DataType.Num.ToBinary(), Players[i].Id.ToBinary(), Players[i].Num.ToBinary() };
                    foreach (var onePlayer in Players)
                    {
                        this.DataCenterProxy.Whisper(onePlayer.Id, dataThrewNum); //通知所有人投掷结果
                    }
                }
                if (Players[i].ThrowTimeOuted) //如果超时,服务器自动帮超时的客户端投掷色子
                {
                    Players[i].ThrowTimeOuted = false;
                    byte[][] dataThrow = { DataType.Action.ToBinary(), ActionType.Throw.ToBinary() };
                    this.ReceiveWhisper(Players[i].Id, dataThrow);
                }
            }
            if (ReadiedPlayers == PlayersAmount && !IsStart)  //当所有玩家均已准备并且玩家数量达到要求后,通知玩家加入开始游戏
            {
                IsStart = true;
                foreach (var onePlayer in Players)
                {
                    onePlayer.TimeOut.Stop();
                    onePlayer.TimeOut.Interval = 10000;
                    onePlayer.TimeOut.Elapsed += (sender1, ea1) =>
                        {
                            onePlayer.ThrowTimeOuted = true;
                        };
                    onePlayer.TimeOut.Start();
                    byte[][] dataStart = { DataType.Action.ToBinary(), ActionType.Start.ToBinary() };
                    this.DataCenterProxy.Whisper(onePlayer.Id, dataStart);  //通知玩家加入开始游戏
                    byte[][] dataTimeOut = { DataType.TimeOutTime.ToBinary(), onePlayer.TimeOut.Interval.ToBinary() };
                    this.DataCenterProxy.Whisper(onePlayer.Id, dataTimeOut); //通知玩家投掷色子的超时时间
                }
                w.WL("所有玩家均已准备,游戏开始..." + Environment.NewLine);
            }
            if (ThrewPlayers == PlayersAmount) //当所有玩家投掷色子结束后,发送结果并统计分数
            {
                ThrewPlayers = 0;
                var TheSamePlayers = 0;
                Players.Sort(Player.ComparePlayerByNum);
                byte[][] dataResult;
                for (int i = Players.Count - 1; i >= 1; i++)
                {
                    if (Players[i] == Players[i - 1])
                    {
                        TheSamePlayers++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (TheSamePlayers == PlayersAmount - 1)
                {
                    dataResult = new byte[][] { DataType.Result.ToBinary(), Result.Same.ToBinary() };
                }
                else
                {
                    for (int i = TheSamePlayers; i < Players.Count; i++)
                    {
                        Players[i].Score += RoundScore;
                    }
                    for (int i = 0; i < Players.Count - TheSamePlayers; i++)
                    {
                        Players[i].Score -= TheSamePlayers * RoundScore / (Players.Count - TheSamePlayers);
                    }
                }
                byte[][] dataScore;
                foreach (var onePlayer in Players)
                {
                    dataScore = new byte[][] { DataType.Score.ToBinary(), onePlayer.Score.ToBinary() };
                    this.DataCenterProxy.Whisper(onePlayer.Id, dataScore);
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
