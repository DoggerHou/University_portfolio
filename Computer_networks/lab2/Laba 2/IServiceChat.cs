using System.ServiceModel;

namespace Laba_2__IP_TCP
{
    [ServiceContract(CallbackContract = typeof(IServiceChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);


        [OperationContract]
        void Disconnect(int id);


        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, int id);
    }


    public interface IServiceChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string msg);
    }
}
