using System.Runtime.Serialization;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    [DataContract]
    public class MessageHeader
    {

        private MessageHeader()
        {
        }

        public MessageHeader(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public byte[] Data { get; private set; }
    }
}