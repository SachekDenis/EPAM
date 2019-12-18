using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMessageHandler
    {
        public List<string> ServerMessages{ get;private set;}
        public void HandleMessage(object sender, EventArgs e)
        {
            ServerMessages.Add((e as MessageEventArgs).Message);
        }
    }
}
