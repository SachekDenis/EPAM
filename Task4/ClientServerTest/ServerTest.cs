using System;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp;

namespace ClientServerTest
{
    /// <summary>
    /// Defines test class ServerTest.
    /// </summary>
    [TestClass]
    public class ServerTest
    {
        /// <summary>
        /// Defines the test method CreatingServerFromValidData.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow("127.0.0.1", 80)]
        [DataRow("192.168.1.1", 250)]
        public void CreatingServerFromValidData(string ip, int port)
        {
            Server server = new Server(ip, port);

            Assert.IsNotNull(server);
        }

        /// <summary>
        /// Defines the test method CreatingServerFromInvalidData.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow(null, 80)]
        public void CreatingServerFromInvalidData(string ip, int port)
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Server(ip, port));
        }

        /// <summary>
        /// Defines the test method TryingSendToUnexistedServerMustThrowExeption.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="message">The message.</param>
        [TestMethod]
        [DataRow("192.168.1.1", 80, "test")]
        public void TryingSendToUnexistedServerMustThrowExeption(string ip, int port, string message)
        {
            Server server = new Server(ip, port);
            Assert.ThrowsException<Exception>(() => server.SendMessage(message));
        }

        /// <summary>
        /// Defines the test method TryingReadFromUnexistedClientMustThrowExeption.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        [TestMethod]
        [DataRow("192.168.1.1", 80)]
        public void TryingReadFromUnexistedClientMustThrowExeption(string ip, int port)
        {
            Server server = new Server(ip, port);
            Assert.ThrowsException<Exception>(() => server.GetMessage());
        }
    }
}
