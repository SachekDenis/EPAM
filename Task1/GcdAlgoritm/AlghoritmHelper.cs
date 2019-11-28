using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Helper class for implementing algorithms
    /// </summary>
    internal class AlghoritmHelper
    {
        /// <summary>
        /// Exchange two numbers using "the three glasses method"
        /// </summary>
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }
}