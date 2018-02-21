using System;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public interface ICommandSerializer
    {
        byte[] Serialize(object command);

        object Deserialize(byte[] message, Type type);
    }
}