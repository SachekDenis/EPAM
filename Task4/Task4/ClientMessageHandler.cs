using CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslitConverter;

namespace Task4
{
    public class ClientMessageHandler
    {
        public string ConvertedMessage{ get;private set;}
        public void HandleMessage(object sender, EventArgs e)
        {
            if(!(e is MessageEventArgs))
                throw new ArgumentException();
            Converter converter = new Converter();
            ConvertedMessage = converter.ToTranslit((e as MessageEventArgs).Message);
        }
    }
}
