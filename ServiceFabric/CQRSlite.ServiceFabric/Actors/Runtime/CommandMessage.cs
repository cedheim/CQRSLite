using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    [DataContract]
    public class CommandMessage
    {
        public static ICommandSerializer Serializer { get; set; } = new JsonCommandSerializer();

        private static readonly MessageHeader[] NoMessageHeaders = new MessageHeader[0];

        [DataMember(Name = "Type")]
        private string _type;

        [DataMember(Name = "Message")]
        private byte[] _message;

        private CommandMessage()
        {
        }

        public CommandMessage(Guid id, object message, IEnumerable<MessageHeader> headers = null)
        {
            Id = id;
            Headers = headers?.ToArray() ?? NoMessageHeaders;

            var type = message.GetType();
            _type = type.AssemblyQualifiedName;
            _message = Serializer.Serialize(message);
        }

        [DataMember]
        public Guid Id { get; private set; }


        [DataMember]
        public MessageHeader[] Headers { get; private set; }


        [IgnoreDataMember] public Type Type => System.Type.GetType(_type);

        [IgnoreDataMember] public object Message => Serializer.Deserialize(_message, Type);
    }
}