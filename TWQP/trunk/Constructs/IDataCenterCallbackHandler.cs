using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IContactCenterCallbackHandler
{
    int ServiceID { get; set; }
    ContactCenterProxy ContactCenterProxy { get; set; }

    void Receive(int id, byte[][] data);
    void ReceiveWhisper(int id, byte[][] data);

    void ServiceEnter(int id);
    void ServiceLeave(int id);

    void JoinSuccessed(int[] serviceIdList);
    void JoinFailed();

    void ConnectField(Exception ex);
    bool Ping(byte[][] o);
}
