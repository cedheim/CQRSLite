using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.ServiceFabric.Actors.Runtime;
using CQRSlite.ServiceFabric.Mocks.Commands;
using CQRSlite.ServiceFabric.Mocks.Domain;
using CQRSlite.ServiceFabric.Mocks.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace CQRSlite.ServiceFabric.Mocks.Actors
{
    [ActorService(Name = "StockItemActorService")]
    public class StockItemActor : DomainActor<StockItem>, IStockItemActor
    {
        private readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());

        public StockItemActor(DomainActorService actorService, ActorId actorId) 
            : base(actorService, actorId)
        {
        }

        public Random Random => _random.Value;

        public async Task<int> GetARandomNumber()
        {
            return await Task.Run(() => Random.Next());
        }
    }
}