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
        /// Initializes a new instance of the <see cref="ServerMessageHandler"/> class.
        /// </summary>
        public ServerMessageHandler()
        {
            ServerMessages = new Dictionary<IPAddress, string>();
        }

        /// <summary>
        /// Gets the server messages.
        /// </summary>
        /// <value>The server messages.</value>
        public Dictionary<IPAddress,string> ServerMessages{get;private set;}
        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentException"></exception>
        public void HandleMessage(object sender, EventArgs e)
        {
            if(!(sender is IPAddress))
                throw new ArgumentException();
            ServerMessages.Add((sender as IPAddress),(e as MessageEventArgs).Message);
        }
    }
}
