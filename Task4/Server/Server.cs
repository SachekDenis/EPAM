using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Server
    {

        public event EventHandler MessageEvent;

        private string _localAdress;

        private int _port;

        private TcpListener server;

        public Server(string localAdress, int port)
        {
            _localAdress = localAdress ?? throw new ArgumentNullException(nameof(localAdress));
            _port = port;
        }

        public void StartServer()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(_localAdress);
                server = new TcpListener(ip, _port);

                server.Start();

            }
            catch (FormatException exception)
            {
                throw new FormatException(exception.Message);
            }
            catch (SocketException exception)
            {
                throw new SocketException(exception.ErrorCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void SendMessage(string message)
        {
            TcpClient client = null;

            NetworkStream stream = null;
            try
            {
                client = server.AcceptTcpClient();

                stream = client.GetStream();

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                stream.Write(messageBytes, 0, messageBytes.Length);

            }
            catch (SocketException exception)
            {
                throw new SocketException(exception.ErrorCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                stream.Close();

                client.Close();
            }
        }


         public void GetMessage()
        {

            byte[] data = new byte[256];
            StringBuilder response = new StringBuilder();

            TcpClient client = null;

            NetworkStream stream = null;
            try
            {

                client = server.AcceptTcpClient();
                stream = client.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                MessageEvent?.Invoke(this,new MessageEventArgs(response.ToString()));
            }
            catch (SocketException exception)
            {
                throw new SocketException(exception.ErrorCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                stream.Close();

                client.Close();
            }
        }

    }
}
