using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslitConverter;

namespace Task4
{
    /// <summary>
    /// Class ClientMessageHandler.
    /// </summary>
    public class ClientMessageHandler
    {
        /// <summary>
        /// Gets the converted message.
        /// </summary>
        /// <value>The converted message.</value>
        public string ConvertedMessage { get; private set; }

        /// <summary>
        /// Handle message.
        /// </summary>
        /// <value>The handle message.</value>
        public EventHandler HandleMessage { get;private set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMessageHandler"/> class.
        /// </summary>
        public ClientMessageHandler()
        {
            ConvertedMessage = string.Empty;

            HandleMessage = (object sender, EventArgs e) =>
            {
                if (!(e is MessageEventArgs))
                    throw new ArgumentException();
                Converter converter = new Converter();
                ConvertedMessage = converter.ToTranslit((e as MessageEventArgs).Message);
            };
        }
    }
}
