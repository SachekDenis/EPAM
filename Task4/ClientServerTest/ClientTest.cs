using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientApp;
using ServerApp;
using System.Threading.Tasks;
using TranslitConverter;

namespace ClientServerTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ClientServerTest()
        {
            //Run server in new thread
            var task = Task.Factory.StartNew(() =>
            {
                Server server = new Server("127.0.0.1", 80);
                server.StartServer();
                server.SendMessage("kkk");
            });

            Client client = new Client("127.0.0.1", 80);
            client.StartListenServer();
        }

        [TestMethod]
        public void TranslitTest()
        {
            Converter converter = new Converter();
            string translit = converter.toTranslit("ягода");
            Assert.AreEqual("yagoda",translit);
        }
    }
}
