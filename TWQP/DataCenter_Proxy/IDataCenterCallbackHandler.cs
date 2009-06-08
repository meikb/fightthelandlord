using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCenter_Proxy
{
    public interface IDataCenterCallbackHandler
    {
        int ServiceID { get; set; }
        DataCenterProxy DataCenterProxy { get; set; }

        void Receive(int id, byte[][] data);
        void ReceiveWhisper(int id, byte[][] data);

        void ServiceEnter(int id);
        void ServiceLeave(int id);

        void JoinSuccessed(int[] serviceIdList);
        void JoinFailed();

        void ConnectField(Exception ex);
        bool Ping(byte[][] o);
    }
}
