using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CQRSlite.ServiceFabric.Mocks.Actors;
using CQRSlite.ServiceFabric.Mocks.Domain;
using FluentAssertions;
using Microsoft.ServiceFabric.Actors;
using NUnit.Framework;
using ServiceFabric.Mocks;

namespace CQRSlite.ServiceFabric.Tests.Actors.Runtime
{
    [TestFixture]
    public class When_calling_an_actor : DomainActorTestBase
    {
        private StockItemActor _stockItemActor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _stockItemActor = StockItemActorService.Activate<StockItemActor>(new ActorId(Data.StockItemActorId));
        }

        [Test]
        public async Task Should_generate_random_numbers()
        {
            var number = await _stockItemActor.GetARandomNumber();

            number.Should().NotBe(0);
        }
    }
}