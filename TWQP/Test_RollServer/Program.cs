using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ConsoleHelper;
using DataCenter_Proxy;
using Extensions;

namespace Test_RollServer
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入小于 100 的 Service ID"));
            new DataCenterCallback(new Handler(id));
            w.WE();
        }
    }

    public class Handler : IDataCenterCallbackHandler
    {
        private Writer w = Writer.Instance;

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
            var dt = data[0].ToObject();
            w.WL(id + " whisper: " + dt.ToString() + Environment.NewLine);
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

    }

    public enum ActionType
    {
        加入 = 1,
        准备 = 2,
        开始 = 3,
    }
}
