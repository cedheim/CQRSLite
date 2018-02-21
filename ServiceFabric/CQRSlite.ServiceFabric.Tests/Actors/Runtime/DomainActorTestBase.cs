using System;
using System.Collections.Generic;
using CQRSlite.Domain;
using CQRSlite.ServiceFabric.Actors.Runtime;
using CQRSlite.ServiceFabric.Mocks.Actors;
using CQRSlite.ServiceFabric.Mocks.Interfaces;
using FakeItEasy;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using ServiceFabric.Mocks;

namespace CQRSlite.ServiceFabric.Tests.Actors.Runtime
{
    public class DomainActorTestBase
    {
        protected readonly ISession Session;
        protected readonly DomainActorService StockItemActorService;

        public DomainActorTestBase()
        {
            Session = A.Fake<ISession>();
            IActorStateProvider actorStateProvider = new MockActorStateProvider();
            actorStateProvider.Initialize(ActorTypeInformation.Get(typeof(StockItemActor)));
            var context = MockStatefulServiceContextFactory.Default;

            StockItemActorService = new DomainActorService(context, 
                ActorTypeInformation.Get(typeof(StockItemActor)), 
                (service, id) => new StockItemActor(service, id), 
                actor => Session, 
                (a, p) => new MockActorStateManager(), 
                actorStateProvider);
        }

        protected static class Data
        {
            public static readonly Guid StockItemActorId = Guid.Parse("a3845212-3c7a-4087-a210-7c58f746b85e");
        }

    }
}