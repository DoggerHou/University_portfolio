using System.ServiceModel;

namespace Laba_2__IP_TCP
{
    class ServerUser
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public OperationContext operationContext { get; set; }
    }
}
