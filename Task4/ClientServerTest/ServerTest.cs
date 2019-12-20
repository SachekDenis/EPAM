using System;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp;

namespace ClientServerTest
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        [DataRow("127.0.0.1", 80)]
        [DataRow("192.168.1.1", 250)]
        public void CreatingServerFromValidData(string ip, int port)
        {
            Server server = new Server(ip, port);

            Assert.IsNotNull(server);
        }

        [TestMethod]
        [DataRow(null, 80)]
        public void CreatingServerFromInvalidData(string ip, int port)
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Server(ip, port));
        }

        [TestMethod]
        [DataRow("192.168.1.1", 80, "test")]
        public void TryingSendToUnexistedServerMustThrowExeption(string ip, int port, string message)
        {
            Server server = new Server(ip, port);
            Assert.ThrowsException<Exception>(() => server.SendMessage(message));
        }

        [TestMethod]
        [DataRow("192.168.1.1", 80)]
        public void TryingReadFromUnexistedClientMustThrowExeption(string ip, int port)
        {
            Server server = new Server(ip, port);
            Assert.ThrowsException<Exception>(() => server.GetMessage());
        }
    }
}
