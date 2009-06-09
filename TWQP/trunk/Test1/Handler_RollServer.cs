using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class Handler_RollServer : IDataCenterCallbackHandler
    {

        public Handler_RollServer(int serviceId)
        {
            this.ServiceID = serviceId;
        }

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {
            Console.WriteLine(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            Console.WriteLine(id + " whisper: " + data + Environment.NewLine);
        }

        public void ServiceEnter(int id)
        {
            Console.WriteLine("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            Console.WriteLine("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            Console.WriteLine("Connected at " + DateTime.Now.ToString() + " with service id " + this.ServiceID + Environment.NewLine);
            Console.Write("Current Service ID List = {");
            foreach (var i in serviceIdList) Console.Write(i + ",");
            Console.Write("}" + Environment.NewLine);
        }

        public void JoinFailed()
        {
            Console.WriteLine("Error: service id " + this.ServiceID + " already exist!");
        }

        public void ConnectField(Exception ex)
        {
            Console.WriteLine("Error: Cannot connect to service!");
            Console.WriteLine(ex.Message);
        }

        public bool Ping(byte[][] data)
        {
            return true;
        }

        #endregion

    }
}
