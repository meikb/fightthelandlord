using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Threading;
using ConsoleHelper;
using Extensions;
using Constructs;

namespace Test_RollServer
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new Handler(id);
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
        /// 观战者集合
        /// </summary>
        private List<Watcher> Watchers = new List<Watcher>();
        /// <summary>
        /// 最大玩加数量
        /// </summary>
        private int PlayersAmount = 3;

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
                    if ((ActionType)Edata == ActionType.Join)
                    {
                        if (Players.Count < PlayersAmount)
                        {
                            Players.Add(new Player(id));
                            w.WL(id + " 已加入游戏 " + Environment.NewLine);
                        }
                        else
                        {
                            Watchers.Add(new Watcher(id));
                            w.WL(id + " 进入游戏观战区 " + Environment.NewLine);
                        }
                    }
                    if ((ActionType)Edata == ActionType.Ready)
                    {
                        int ReadyPlayers = 0;
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Id == id)
                            {
                                onePlayer.IsReady = true;
                            }
                        }
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.IsReady)
                            {
                                ReadyPlayers++;
                            }
                        }
                        if (ReadyPlayers == Players.Count)
                        {
                            byte[][] dataStart = {DataType.Action.ToBinary(),ActionType.Start.ToBinary()};
                            foreach (Player onePlayer in Players)
                            {
                                DataCenterProxy.Whisper(onePlayer.Id, dataStart);
                            }
                        }
                        w.WL(id + " 已准备 " + Environment.NewLine);
                    }
                    if ((ActionType)Edata == ActionType.Throw)
                    {
                        bool everyOneWasThrew = false;
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Id == id)
                            {
                                onePlayer.Num = new Random().Next(1, 7);
                                byte[][] dataNum = {DataType.Num.ToBinary(),onePlayer.Num.ToBinary()};
                                DataCenterProxy.Whisper(id, dataNum);
                                foreach (Player otherPlayer in Players)
                                {
                                    if (otherPlayer.Id != id)
                                    {
                                        byte[][] dataOtherNum = { DataType.OtherNum.ToBinary(), id.ToBinary(), onePlayer.Num.ToBinary() };
                                        DataCenterProxy.Whisper(otherPlayer.Id, dataOtherNum);
                                    }
                                }
                            }
                        }
                        foreach (Player onePlayer in Players)
                        {
                            if (onePlayer.Num != 0)
                            {
                                everyOneWasThrew = true;
                            }
                            else
                            {
                                everyOneWasThrew = false;
                            }
                        }
                        if (everyOneWasThrew)
                        {
                            Players.Sort(Player.ComparePlayerByNum);
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
            w.W(60, 0, true, ConsoleColor.White, ConsoleColor.Black, DateTime.Now.ToString());
        }

        public void Exit()
        {
            w.WE();
        }

        #endregion
    }

}
