using System;
using System.Net;
using System.Threading.Tasks;
using ClientApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp;
using Task4;

namespace ClientServerTest
{
    [TestClass]
    public class ClientServerTest
    {
        [TestMethod]
        [DataRow("127.0.0.1",80,"русский","russkij")]
        public void ClientReadServerWriteTest(string ip, int port, string serverString, string convertedMessage)
        {
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server(ip, port);
                server.StartServer();
                server.SendMessage(serverString);
            });

            Client client = new Client(ip, port);
            ClientMessageHandler messageHandler = new ClientMessageHandler();
            client.MessageEvent += messageHandler.HandleMessage;
            client.GetMessage();

            Assert.AreEqual(convertedMessage, messageHandler.ConvertedMessage);
        }

        [TestMethod]
        [DataRow("127.0.0.1",80,"русский","русский")]
        public void ClientWriteServerReadTest(string ip, int port, string clientString, string receivedMessage)
        {
            ServerMessageHandler messageHandler = new ServerMessageHandler();
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server(ip, port);
                server.MessageEvent+=messageHandler.HandleMessage;
                server.StartServer();
                server.GetMessage();
                Assert.AreEqual(receivedMessage,messageHandler.ServerMessages[IPAddress.Parse(ip)]);
            });

            Client client = new Client(ip, port);
            client.SendMessage(clientString);

        }


        [TestMethod]
        [DataRow("127.0.0.1",80,"русский","russkij")]
        public void ClientReadMultipleServerWriteTest(string ip, int port, string serverString, string convertedMessage)
        {
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server(ip, port);
                server.StartServer();
                server.SendMessage(serverString);
            });

            Client client = new Client(ip, port);
            ClientMessageHandler firstMessageHandler = new ClientMessageHandler();
            ClientMessageHandler secondMessageHandler = new ClientMessageHandler();
            client.MessageEvent += firstMessageHandler.HandleMessage;
            client.MessageEvent += secondMessageHandler.HandleMessage;

            client.GetMessage();

            Assert.AreEqual(convertedMessage, firstMessageHandler.ConvertedMessage);
            Assert.AreEqual(convertedMessage, secondMessageHandler.ConvertedMessage);
        }

        [TestMethod]
        [DataRow("127.0.0.1",80,"русский","русский")]
        public void ClientWriteServerReadMultipleTest(string ip, int port, string clientString, string receivedMessage)
        {
            ServerMessageHandler firstMessageHandler = new ServerMessageHandler();
            ServerMessageHandler secondMessageHandler = new ServerMessageHandler();
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server(ip, port);
                server.MessageEvent+=firstMessageHandler.HandleMessage;
                server.MessageEvent+=secondMessageHandler.HandleMessage;
                server.StartServer();
                server.GetMessage();
                Assert.AreEqual(receivedMessage,firstMessageHandler.ServerMessages[IPAddress.Parse(ip)]);
                Assert.AreEqual(receivedMessage,secondMessageHandler.ServerMessages[IPAddress.Parse(ip)]);
            });

            Client client = new Client(ip, port);
            client.SendMessage(clientString);

        }
    }
}
