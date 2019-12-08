using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class UnableToPaintExeption.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class UnableToPaintException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToPaintExeption"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnableToPaintException(string message) : base(message)
        {}
    }
}
