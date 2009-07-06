// This code was generated by a svcutil tool
// Modified by Nikola Paljetak

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(CallbackContract = typeof(IContactCenterCallback), SessionMode = System.ServiceModel.SessionMode.Required)]
public interface IContactCenter
{

    [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IContactCenter/Join", ReplyAction = "http://tempuri.org/IContactCenter/JoinResponse")]
    System.IAsyncResult BeginJoin(int id, System.AsyncCallback callback, object asyncState);

    int[] EndJoin(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, Action = "http://tempuri.org/IContactCenter/Leave")]
    void Leave();

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, Action = "http://tempuri.org/IContactCenter/Say")]
    void Say(byte[][] data);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, Action = "http://tempuri.org/IContactCenter/Whisper")]
    void Whisper(int to, byte[][] data);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IContactCenterCallback
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IContactCenter/Receive")]
    void Receive(int senderId, byte[][] data);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IContactCenter/ReceiveWhisper")]
    void ReceiveWhisper(int senderId, byte[][] data);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IContactCenter/ServiceEnter")]
    void ServiceEnter(int id);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IContactCenter/ServiceLeave")]
    void ServiceLeave(int id);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IContactCenter/Ping", ReplyAction = "http://tempuri.org/IContactCenter/PingResponse")]
    bool Ping(byte[][] data);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IContactCenterChannel : IContactCenter, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ContactCenterProxy : System.ServiceModel.DuplexClientBase<IContactCenter>, IContactCenter
{

    public ContactCenterProxy(System.ServiceModel.InstanceContext callbackInstance)
        :
            base(callbackInstance)
    {
    }

    public ContactCenterProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName)
        :
            base(callbackInstance, endpointConfigurationName)
    {
    }

    public ContactCenterProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress)
        :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public ContactCenterProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public ContactCenterProxy(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(callbackInstance, binding, remoteAddress)
    {
    }

    public System.IAsyncResult BeginJoin(int id, System.AsyncCallback callback, object asyncState)
    {
        return base.Channel.BeginJoin(id, callback, asyncState);
    }

    public int[] EndJoin(System.IAsyncResult result)
    {
        return base.Channel.EndJoin(result);
    }

    public void Leave()
    {
        base.Channel.Leave();
    }

    public void Say(byte[][] data)
    {
        base.Channel.Say(data);
    }

    public void Whisper(int to, byte[][] data)
    {
        base.Channel.Whisper(to, data);
    }
}

