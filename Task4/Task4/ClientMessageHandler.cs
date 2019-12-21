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
        public string ConvertedMessage{ get;private set;}

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentException"></exception>
        public void HandleMessage(object sender, EventArgs e)
        {
            if(!(e is MessageEventArgs))
                throw new ArgumentException();
            Converter converter = new Converter();
            ConvertedMessage = converter.ToTranslit((e as MessageEventArgs).Message);
        }
    }
}
