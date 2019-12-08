using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class UnableToCutShapeException.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class UnableToCutShapeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToCutShapeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnableToCutShapeException(string message) : base(message)
        { }
    }
}
