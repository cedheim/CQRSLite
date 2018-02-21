using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public interface ICommandActor : IActor
    {
        Task Handle(CommandMessage message, CancellationToken cancellationToken);
    }
}