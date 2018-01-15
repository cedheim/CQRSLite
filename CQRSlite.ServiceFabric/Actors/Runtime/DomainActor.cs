using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Domain;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public abstract class DomainActor<T> : Actor where T : AggregateRoot
    {
        protected DomainActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }
    }
}
