using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientApp;
using ServerApp;
using System.Threading.Tasks;
using TranslitConverter;
using Task4;
using System.Net.Sockets;

namespace ClientServerTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        [DataRow("127.0.0.1",80)]
        [DataRow("192.168.1.1", 250)]
        public void CreatingClientFromValidData(string ip, int port)
        {
            Client client = new Client(ip, port);

            Assert.IsNotNull(client);
        }

        [TestMethod]
        [DataRow(null, 80)]
        public void CreatingClientFromInvalidData(string ip, int port)
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client(ip, port));
        }

        [TestMethod]
        [DataRow("192.168.1.1", 80,"test")]
        public void TryingSendToUnexistedServerMustThrowExeption(string ip, int port, string message)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.SendMessage(message));
        }

        [TestMethod]
        [DataRow("192.168.1.1", 80)]
        public void TryingReadFromUnexistedServerMustThrowExeption(string ip, int port)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.GetMessage());
        }

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
            client.GetMessage();

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
            client.SendMessage("kkk");
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
