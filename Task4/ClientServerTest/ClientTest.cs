using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientApp;
using ServerApp;
using System.Threading.Tasks;
using TranslitConverter;
using System.Net.Sockets;

namespace ClientServerTest
{
    /// <summary>
    /// Defines test class ClientTest.
    /// </summary>
    [TestClass]
    public class ClientTest
    {
        /// <summary>
        /// Defines the test method CreatingClientFromValidData.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow("127.0.0.1",80)]
        [DataRow("192.168.1.1", 250)]
        public void CreatingClientFromValidData(string ip, int port)
        {
            Client client = new Client(ip, port);

            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Defines the test method CreatingClientFromInvalidData.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow(null, 80)]
        public void CreatingClientFromInvalidData(string ip, int port)
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Client(ip, port));
        }

        /// <summary>
        /// Defines the test method TryingSendToUnexistedServerMustThrowExeption.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="message">The message.</param>
        [TestMethod]
        [DataRow("255.255.255.0", 80,"test")]
        public void TryingSendToUnexistedServerMustThrowExeption(string ip, int port, string message)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.SendMessage(message));
        }

        /// <summary>
        /// Defines the test method TryingReadFromUnexistedServerMustThrowExeption.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow("255.255.255.0", 80)]
        public void TryingReadFromUnexistedServerMustThrowExeption(string ip, int port)
        {
            Client client = new Client(ip, port);
            Assert.ThrowsException<SocketException>(() => client.GetMessage());
        }
    }
}
