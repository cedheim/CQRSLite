using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSlite.ServiceFabric.Events
{
    public class EventPublisher : IEventPublisher
    {
        public async Task Publish<T>(T @event, CancellationToken cancellationToken) where T : class, IEvent
        {
            throw new NotImplementedException();
        }
    }
}
