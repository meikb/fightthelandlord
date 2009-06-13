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


    // todo
    [Serializable]
    public class Character : OO.User_Character
    {
        
    }
    //public class State
    //{
    //}
    //public class Score
    //{
    //}
}
