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
        [DataRow("255.255.255.255", 80,"test")]
        public void TryingSendToUnexistedServerMustThrowExeption(string ip, int port, string message)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.SendMessage(message));
        }

        [TestMethod]
        [DataRow("255.255.255.0", 80)]
        public void TryingReadFromUnexistedServerMustThrowExeption(string ip, int port)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.GetMessage());
        }
    }
}
