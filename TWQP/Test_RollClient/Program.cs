using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ConsoleHelper;
using DataCenter_Proxy;
using Extensions;

namespace Test_RollClient
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Player ID"));
            Handler hl = new Handler(id);
            new DataCenterCallback(hl);
            w.WE();
            w.RL("请输入你要加入的服务器ID");
            //int selectId = Convert.ToInt32(Console.ReadLine());
            byte[][] data = new byte[1][];
            data[0] = ActionType.加入.ToBinary();
            hl.DataCenterProxy.Whisper(1, data);
            w.WE();
        }
    }

    public class Handler : IDataCenterCallbackHandler
    {
        private Writer w = Writer.Instance;
        private object _syncObj = new object();
        private List<int> _rollServiceIdList = new List<int>();

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
                if (id < 100) _rollServiceIdList.Add(id);

            w.WL("已于" + DateTime.Now.ToString() + " 连入数据中心");
            if (_rollServiceIdList.Count > 0)
            {
                w.W("发现 Roll 游戏服务器：");
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

    public enum ActionType
    {
        加入 = 1,
        准备 = 2,
        开始 = 3,
    }
}
