using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientApp;
using ServerApp;
using System.Threading.Tasks;
using TranslitConverter;
using Task4;

namespace ClientServerTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ClientReadServerWriteTest()
        {
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server("127.0.0.1", 80);
                server.StartServer();
                server.SendMessage("русский");
            });

            Client client = new Client("127.0.0.1", 80);
            ClientMessageHandler messageHandler = new ClientMessageHandler();
            client.MessageEvent+= messageHandler.HandleMessage;
            client.ListenServer();

            Assert.AreEqual("russkij",messageHandler.ConvertedMessage);
        }

        [TestMethod]
        public void ClientWriteServerReadTest()
        {
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server("127.0.0.1", 80);
                server.StartServer();
                server.GetMessage();
            });

            Client client = new Client("127.0.0.1", 80);
            client.SendToServer("kkk");
        }

        [TestMethod]
        public void TranslitTest()
        {
            Converter converter = new Converter();
            string translit = converter.ToTranslit("ягода");
            Assert.AreEqual("yagoda",translit);
        }
    }
}
