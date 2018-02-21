using System;
using System.Fabric;
using CQRSlite.Domain;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public class DomainActorService : ActorService
    {
        public DomainActorService(
            StatefulServiceContext context, 
            ActorTypeInformation actorTypeInfo, 
            Func<DomainActorService, ActorId, ActorBase> actorFactory = null, 
            Func<Actor, ISession> sessionFactory = null,
            Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory = null, 
            IActorStateProvider stateProvider = null, 
            ActorServiceSettings settings = null) 
            : base(context, actorTypeInfo, (actorService, actorId) => ((actorFactory ?? DefaultActorFactory)((DomainActorService)actorService, actorId)), stateManagerFactory, stateProvider, settings)
        {
            SessionFactory = sessionFactory ?? DefaultSessionFactory;
        }

        public Func<Actor, ISession> SessionFactory { get; }

        private ISession DefaultSessionFactory(Actor actor)
        {
            throw new NotImplementedException();
        }

        private static ActorBase DefaultActorFactory(DomainActorService actorService, ActorId actorId)
        {
            return (ActorBase)Activator.CreateInstance(
                actorService.ActorTypeInformation.ImplementationType,
                actorService,
                actorId);
        }
    }
}