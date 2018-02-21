using System;
using System.Text;

namespace CQRSlite.ServiceFabric.Actors.Runtime
{
    public class JsonCommandSerializer : ICommandSerializer
    {
        public byte[] Serialize(object command)
        {
            return Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(command));
        }

        public object Deserialize(byte[] message, Type type)
        {
            var json = Encoding.UTF8.GetString(message);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
        }
    }
}