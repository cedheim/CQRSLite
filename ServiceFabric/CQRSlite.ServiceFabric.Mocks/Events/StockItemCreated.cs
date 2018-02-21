using System;
using System.Runtime.Serialization;

namespace CQRSlite.ServiceFabric.Mocks.Events
{
    [DataContract]
    public class StockItemCreated : CQRSlite.Events.IEvent
    {
        private StockItemCreated()
        {
        }

        public StockItemCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Version { get; set; }

        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
    }
}