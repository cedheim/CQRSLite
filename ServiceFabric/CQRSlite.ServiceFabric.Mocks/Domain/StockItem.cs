using System;
using System.Runtime.Serialization;
using CQRSlite.Domain;
using CQRSlite.ServiceFabric.Mocks.Events;

namespace CQRSlite.ServiceFabric.Mocks.Domain
{
    public class StockItem : AggregateRoot
    {
        private StockItem()
        {
        }

        public StockItem(Guid id, string name)
        {
            Id = id;

            ApplyChange(new StockItemCreated(id, name));
        }

        public string Name { get; private set; }

        private void Apply(StockItemCreated e)
        {
            Name = e.Name;
        }
    }
}