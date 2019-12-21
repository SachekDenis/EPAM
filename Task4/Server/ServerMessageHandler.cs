using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    /// <summary>
    /// Class ServerMessageHandler.
    /// </summary>
    public class ServerMessageHandler
    {

        /// <summary>
        /// Gets the server messages.
        /// </summary>
        /// <value>The server messages.</value>
        public Dictionary<IPAddress, string> ServerMessages { get; private set; }

        /// <summary>
        /// Handle message.
        /// </summary>
        /// <value>The handle message.</value>
        public EventHandler HandleMessage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessageHandler" /> class.
        /// </summary>
        public ServerMessageHandler()
        {
            ServerMessages = new Dictionary<IPAddress, string>();

            HandleMessage = (object sender, EventArgs e) =>
            {
                if (!(sender is IPAddress))
                    throw new ArgumentException();
                ServerMessages.Add((sender as IPAddress), (e as MessageEventArgs).Message);
            };
        }
    }
}
