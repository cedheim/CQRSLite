using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.ServiceFabric.Actors.Runtime;
using CQRSlite.ServiceFabric.Mocks.Commands;
using Microsoft.ServiceFabric.Actors;

namespace CQRSlite.ServiceFabric.Mocks.Interfaces
{
    public interface IStockItemActor : ICommandActor
    {
        Task<int> GetARandomNumber();
    }
}