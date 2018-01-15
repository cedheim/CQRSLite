using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSlite.ServiceFabric.Commands
{
    public class CommandSender : ICommandSender
    {
        public async Task Send<T>(T command, CancellationToken cancellationToken) where T : class, ICommand
        {
            throw new NotImplementedException();
        }
    }
}
