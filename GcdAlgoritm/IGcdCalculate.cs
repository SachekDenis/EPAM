using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Gcd Calcualting Interface
    /// </summary>
    public interface IGcdCalculating
    {
        /// <summary>
        /// Calculating of GCD
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <returns>GCD</returns>
        int CalculateGcd(int a, int b);
    }
}