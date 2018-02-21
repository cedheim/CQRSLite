using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using CQRSlite.ServiceFabric.Actors.Runtime;
using CQRSlite.ServiceFabric.Mocks.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace CQRSlite.ServiceFabric.Tests.Actors.Runtime
{
    [TestFixture]
    public class When_serializing_a_command_message
    {
        private DataContractSerializer _serializer;
        private CreateStockItem _command;
        private CommandMessage _message;
        private CommandMessage _result;
        private string _xml;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _serializer = new DataContractSerializer(typeof(CommandMessage));
            _command = new CreateStockItem("TEST");
            _message = new CommandMessage(Guid.NewGuid(), _command, new [] { new MessageHeader("TEST", Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())) });

            using (var stream = new MemoryStream())
            {
                _serializer.WriteObject(stream, _message);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                _result  = _serializer.ReadObject(stream) as CommandMessage;

                _xml = Encoding.UTF8.GetString(stream.GetBuffer());

                Console.WriteLine(_xml);
            }

        }

        [Test]
        public void When_serializing_should_retain_values()
        {
            _result.Type.ShouldBeEquivalentTo(_message.Type);
            _result.Message.ShouldBeEquivalentTo(_command);
            _result.Id.ShouldBeEquivalentTo(_message.Id);
            _result.Headers.ShouldBeEquivalentTo(_message.Headers);

        }
    }
}