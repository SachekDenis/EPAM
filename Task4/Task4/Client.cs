using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    /// <summary>
    /// Class Client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Occurs when recived message.
        /// </summary>
        public event EventHandler MessageEvent;

        /// <summary>
        /// The server adress
        /// </summary>
        private string _serverAdress;

        /// <summary>
        /// The port
        /// </summary>
        private int _port;

        /// <summary>
        /// The server stream
        /// </summary>
        private NetworkStream _serverStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="serverAdress">The server adress.</param>
        /// <param name="port">The port.</param>
        /// <exception cref="ArgumentNullException">serverAdress</exception>
        public Client(string serverAdress, int port)
        {
            _serverAdress = serverAdress ?? throw new ArgumentNullException(nameof(serverAdress));
            this._port = port;
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
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(_serverAdress, _port);
                _serverStream = client.GetStream();

                do
                {
                    int bytes = _serverStream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (_serverStream.DataAvailable);

                MessageEvent?.Invoke(this,new MessageEventArgs(response.ToString()));
            }
            catch (SocketException exeption)
            {
                throw new SocketException(exeption.ErrorCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                client.Close();
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
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(_serverAdress, _port);
                _serverStream = client.GetStream();

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                _serverStream.Write(messageBytes, 0, messageBytes.Length);

            }
            catch (SocketException exeption)
            {
                throw new SocketException(exeption.ErrorCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
