using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class UnableToPaintExeption : Exception
    {
        public UnableToPaintExeption(string message) : base(message)
        {}
    }
}
