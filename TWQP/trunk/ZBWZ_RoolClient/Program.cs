using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using ConsoleHelper;
using Extensions;
using ZBWZ;

namespace ZBWZ_RollClient
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var id = int.Parse(w.RL("请输入小于 100 的 Service ID"));
            var h = new Handler(id);
            new DataCenterCallback(h);  // 连接至 DataCenter 并准备好回调实例
            h.ServerId = int.Parse(w.RL("请选择一个服务器"));
            var Data = new byte[][] { DataType.Action.ToBinary(), ActionType.CanIJoinIt.ToBinary() };
            h.DataCenterProxy.Whisper(h.ServerId, Data);
            Timer t = new Timer();
            t.Elapsed += (sender1, ea1) =>
            {
                t.Stop();
                while (true)
                {
                    h.kb = Console.ReadKey(true);
                }

            };
            t.Start();
            new GameLooper(h).Loop();   // 创建游戏循环并运行
            
        }
    }

    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        private Writer w = Writer.Instance;
        private object _syncObj = new object();
        private List<int> _rollServiceIdList = new List<int>();
        private Player I = new Player();
        public ConsoleKeyInfo kb { get; set; }
        public int ServerId { get; set; }
        private bool IsStart = false;
        private ElapsedEventHandler _elapsedEventHandler = null;

        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {
            w.WL(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            DataType dataType = data[0].ToObject<DataType>();
            switch (dataType)
            {
                case DataType.Action:
                    ActionType actionType = data[1].ToObject<ActionType>();
                    if (actionType == ActionType.YouCanJoinIt)
                    {
                        byte[][] dataJoin = { DataType.Action.ToBinary(), ActionType.Join.ToBinary() };
                        this.DataCenterProxy.Whisper(ServerId, dataJoin);

                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "正在加入服务器  {0} ", ServerId);
                    }
                    if (actionType == ActionType.YouCanNotJoinIt)
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "服务器  {0}  玩家已满,请稍后再试", ServerId);
                    }
                    if (actionType == ActionType.JoinedSuccess)
                    {
                        I.Joined = true;
                        var tempTimer = new Timer(1000);
                        var readyTime = 15;
                        tempTimer.Elapsed += (sender1, ea1) =>
                            {
                                if (readyTime >= 0)
                                {
                                    w.W(60, 3, true, ConsoleColor.Red, ConsoleColor.Black, "请在  {0}  秒内准备", readyTime--.ToString());
                                }
                                else
                                {
                                    w.W(60, 3, true, ConsoleColor.Red, ConsoleColor.Black, "                    ");
                                    tempTimer.Stop();
                                    tempTimer.Dispose();
                                }
                            };
                    }
                    if (actionType == ActionType.Out)
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "被服务器T出...");
                        I = new Player(ServiceID);
                    }
                    if (actionType == ActionType.Start)
                    {
                        this.IsStart = true;
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "所有玩家准备就绪,开始游戏...");
                    }
                    break;
                case DataType.Num:
                    int NumId = data[1].ToObject<int>();
                    int num = data[2].ToObject<int>();
                    if (I.Id == NumId)
                    {
                        I.IsThrew = true;
                        I.Num = num;

                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "您丢出的色子点数为: {0}",I.Num.ToString());
                    }
                    else
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "玩家 {0} 丢出的色子点数为: {1}",NumId.ToString() , num.ToString());
                    }
                    break;
                case DataType.TimeOutTime:
                    double timeOutTime = data[1].ToObject<double>();
                    int RTime = (int)timeOutTime/1000;
                    I.TimeOut.Interval = 1000;
                    _elapsedEventHandler = (sender, ea1) =>
                    {
                        w.W(60, 5, true, ConsoleColor.Red, ConsoleColor.Black, "请在  {0}  秒内投掷 ", RTime--.ToString());
                        if (RTime == 0)
                        {
                            if (!I.IsThrew)
                            {
                                w.WL("超时,自动投掷色子" + Environment.NewLine);
                            }
                            I.TimeOut.Stop();
                            I.TimeOut.Elapsed -= _elapsedEventHandler;
                        }
                    };
                    I.TimeOut.Elapsed += _elapsedEventHandler;
                    I.TimeOut.Start();
                    break;
                case DataType.Score:
                    I.Score = data[1].ToObject<int>();
                    break;
                case DataType.Result:
                    Result result = (Result)data[1].ToObject<Result>();
                    if (result == Result.Same)
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "本局持平");

                    }
                    if (result == Result.Lose)
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "您输了");
                    }
                    if (result == Result.Win)
                    {
                        w.W(60, 40, true, ConsoleColor.Red, ConsoleColor.Black, "您赢了");
                    }
                    I = new Player(ServiceID);
                    break;
            }
            //w.WL(id + " whisper: " + data + Environment.NewLine);
        }

        public void ServiceEnter(int id)
        {
            if (id > 100)
            {
                lock (_syncObj)
                {
                    if (!_rollServiceIdList.Contains(id)) _rollServiceIdList.Add(id);
                    // todo
                }
            }
            w.WL("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            if (id > 100)
            {
                lock (_syncObj)
                {
                    if (_rollServiceIdList.Contains(id)) _rollServiceIdList.Remove(id);
                    // todo
                }
            }
            w.WL("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            foreach (var id in serviceIdList)
                if (id > 100) _rollServiceIdList.Add(id);

            w.WL("已于" + DateTime.Now.ToString() + " 连入数据中心");
            if (_rollServiceIdList.Count > 0)
            {
                w.W("发现 Roll 游戏服务器：");
                w.W("请输入服务器ID加入相应服务器" + Environment.NewLine);
                w.W<int>(_rollServiceIdList);
                w.WL();
            }
            else
            {
                w.W("未发现任何 Roll 游戏服务器！");
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
游戏开始运行.
类型：RollGame Client
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
        }

        public void Process()
        {
            w.W(60, 0, true, ConsoleColor.White, ConsoleColor.Black, DateTime.Now.ToString());
            w.W(40, 18, true, ConsoleColor.Red, ConsoleColor.Black, "分数: {0}", I.Score.ToString());
            if (I.Joined && !I.IsReady)
            {
                w.W(40, 20, true, ConsoleColor.Red, ConsoleColor.Black, "请按\"R\"键准备");
            }
            if (!I.IsThrew)
            {
                w.W(40, 22, true, ConsoleColor.Red, ConsoleColor.Black, "请按\"T\"键投掷色子");
            }
            switch (kb.Key)
            {
                case ConsoleKey.R:
                    kb = new ConsoleKeyInfo();
                    if (!this.I.IsReady && I.Joined)
                    {
                        this.I.IsReady = true;
                        byte[][] dataReady = { DataType.Action.ToBinary(), ActionType.Ready.ToBinary() };
                        this.DataCenterProxy.Whisper(this.ServerId, dataReady);
                        w.W(40, 20, true, ConsoleColor.Red, ConsoleColor.Black, "已准备           ");
                    }
                    break;
                case ConsoleKey.T:
                    kb = new ConsoleKeyInfo();
                    if (this.IsStart && !I.IsThrew)
                    {
                        I.IsThrew = true;
                        this.IsStart = false;
                        byte[][] dataThrow = { DataType.Action.ToBinary(), ActionType.Throw.ToBinary() };
                        this.DataCenterProxy.Whisper(this.ServerId, dataThrow);
                        w.W(40, 22, true, ConsoleColor.Red, ConsoleColor.Black, "已投掷           ");
                    }
                    break;
            }
        }

        public void Exit()
        {
            w.WE();
        }

        #endregion

    }
}
