using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ConsoleHelper;
using Extensions;
using ZBWZ;

namespace Test_RollClient
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入小于 100 的 Player ID"));
            var h = new Handler(id);
            new DataCenterCallback(h);
            var selectId = int.Parse(w.RL("请选择服务器"));
            var Data = new byte[][] { DataType.Action.ToBinary(), ActionType.Join.ToBinary() };
            h.DataCenterProxy.Whisper(selectId, Data);
            w.WL("准备请按回车" + Environment.NewLine);
            Console.ReadLine();
            byte[][] dataRelay = { DataType.Action.ToBinary(), ActionType.Ready.ToBinary() };
            h.DataCenterProxy.Whisper(selectId, dataRelay);
            while (true)
            {
                w.WE();
            }
        }
    }

    public class Handler : IDataCenterCallbackHandler
    {
        private Writer w = Writer.Instance;
        private object _syncObj = new object();
        private List<int> _rollServiceIdList = new List<int>();
        private Player I = new Player();

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
                        w.WL("所有玩家准备就绪,开始游戏..." + Environment.NewLine + "请按回车投掷色子" + Environment.NewLine);
                        Console.ReadLine();
                        byte[][] dataThrow = { DataType.Action.ToBinary(), ActionType.Throw.ToBinary() };
                        this.DataCenterProxy.Whisper(this.ServiceID, dataThrow);
                        w.WE();
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
                w.W("请输入服务器ID加入相应服务器");
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

    }
}
