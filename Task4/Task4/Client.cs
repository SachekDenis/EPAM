using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Client
    {
        private delegate string CodeMessage(string message);

        event CodeMessage codeMessageEvent;

        private string _serverAdress;

        private int _port;

        private NetworkStream _serverStream;

        public Client(string serverAdress, int port)
        {
            _serverAdress = serverAdress ?? throw new ArgumentNullException(nameof(serverAdress));
            this._port = port;
        }

        public void StartListenServer()
        {
            byte[] data = new byte[256];
            StringBuilder response = new StringBuilder();
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(_serverAdress, _port);
                _serverStream = client.GetStream();

                while (true)
                {

                    do
                    {
                        int bytes = _serverStream.Read(data, 0, data.Length);
                        response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (_serverStream.DataAvailable);

                    codeMessageEvent?.Invoke(response.ToString());

                }
            }
            catch (SocketException exeption)
            {
                throw new SocketException(exeption.ErrorCode);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
