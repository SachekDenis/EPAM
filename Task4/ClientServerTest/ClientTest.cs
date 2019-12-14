using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientApp;
using ServerApp;
using System.Threading.Tasks;

namespace ClientServerTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Run server in new thread
            Task.Factory.StartNew(() =>
            {
                Server server = new Server("127.0.0.1", 80);
                server.StartServer();
                server.SendMessage("kkk");
            });

            Client client = new Client("127.0.0.1", 80);
            client.StartListenServer();
        }
    }
}
