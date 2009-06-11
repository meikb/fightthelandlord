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
        public bool IsStart = false;

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
                    if (actionType == ActionType.Start)
                    {
                        this.IsStart = true;
                        w.WL("所有玩家准备就绪,开始游戏..." + Environment.NewLine );
                    }
                    break;
                case DataType.Num:
                    int num = data[1].ToObject<int>();
                    I.Num = num;
                    w.WL("您丢出的色子点数为 " + I.Num.ToString() + Environment.NewLine);
                    w.WE();
                    break;
            }
            w.WL(id + " whisper: " + data + Environment.NewLine);
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
            switch (kb.Key)
            {
                case ConsoleKey.R:
                    if (!this.I.IsReady)
                    {
                        this.I.IsReady = true;
                        byte[][] dataRelay = { DataType.Action.ToBinary(), ActionType.Ready.ToBinary() };
                        this.DataCenterProxy.Whisper(this.ServerId, dataRelay);
                        
                    }
                    else
                    {
                        //w.WL("您已经准备过了" + Environment.NewLine);
                    } 
                    break;
                case ConsoleKey.T:
                    if (this.IsStart)
                    {
                        this.IsStart = false;
                        byte[][] dataThrow = { DataType.Action.ToBinary(), ActionType.Throw.ToBinary() };
                        this.DataCenterProxy.Whisper(this.ServerId, dataThrow);
                    }
                    else
                    {
                        //w.WL("您已经投掷过色子了" + Environment.NewLine);
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
