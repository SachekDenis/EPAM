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
    /// <summary>
    /// Class Server.
    /// </summary>
    public class Server
    {

        /// <summary>
        /// Occurs when recived message.
        /// </summary>
        public event EventHandler MessageEvent;

        /// <summary>
        /// The local adress
        /// </summary>
        private string _localAdress;

        /// <summary>
        /// The port
        /// </summary>
        private int _port;

        /// <summary>
        /// The server
        /// </summary>
        private TcpListener server;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="localAdress">The local adress.</param>
        /// <param name="port">The port.</param>
        /// <exception cref="ArgumentNullException">localAdress</exception>
        public Server(string localAdress, int port)
        {
            _localAdress = localAdress ?? throw new ArgumentNullException(nameof(localAdress));
            _port = port;
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="SocketException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="SocketException"></exception>
        /// <exception cref="Exception"></exception>
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
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }


        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <exception cref="SocketException"></exception>
        /// <exception cref="Exception"></exception>
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


                //Send Ip of client and message from it

                MessageEvent?.Invoke((client.Client.RemoteEndPoint as IPEndPoint).Address, new MessageEventArgs(response.ToString()));
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
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

    }
}
