using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSlite.ServiceFabric.Exceptions;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public abstract class DomainActor<T> : Actor where T : AggregateRoot
    {
        private readonly ActorId _actorId;

        protected DomainActor(DomainActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            if (actorId.Kind != ActorIdKind.Guid)
            {
                throw new ArgumentException("ActorId needs to be of Guid type.", nameof(actorId));
            }
            
            _actorId = actorId;

            Session = actorService.SessionFactory(this);
        }

        protected ISession Session { get; }
        
        public Task Handle(CommandMessage message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
