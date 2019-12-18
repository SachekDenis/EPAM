using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMessageHandler
    {
        public Dictionary<IPAddress,string> ServerMessages{get;private set;}
        public void HandleMessage(object sender, EventArgs e)
        {
            if(!(sender is IPAddress))
                throw new ArgumentException();
            ServerMessages.Add((sender as IPAddress),(e as MessageEventArgs).Message);
        }
    }
}
