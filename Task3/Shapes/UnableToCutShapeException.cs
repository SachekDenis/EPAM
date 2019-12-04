using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class UnableToCutShapeException : Exception
    {
        public UnableToCutShapeException(string message) : base(message)
        { }
    }
}
