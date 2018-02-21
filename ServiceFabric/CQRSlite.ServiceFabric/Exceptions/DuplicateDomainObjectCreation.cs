using System;
using System.Runtime.Serialization;

namespace CQRSlite.ServiceFabric.Exceptions
{
    [Serializable]
    public class DuplicateDomainObjectCreation : Exception
    {
        public DuplicateDomainObjectCreation()
        {
        }

        public DuplicateDomainObjectCreation(string message) : base(message)
        {
        }

        public DuplicateDomainObjectCreation(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateDomainObjectCreation(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}