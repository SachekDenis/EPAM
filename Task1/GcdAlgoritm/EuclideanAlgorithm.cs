using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Implementation of the Euclidean algorithm for computing GCD
    /// </summary>
    public class EuclideanAlgorithm : IGcdCalculating
    {
        /// <summary>
        /// Euclidean algorithm for computing the GCD of two integers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD of two integers</returns>
        public int CalculateGcd(int a, int b)
        {
            // If one number is zero, then the other will be a GCD
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            //If the numbers are negative, then the GCD is calculated from their absolute value
            if (a < 0)
                a = Math.Abs(a);
            if (b < 0)
                b = Math.Abs(b);

            //The process repeats until the numbers become equal
            while (a != b)
            {
                if (a > b)
                {
                    AlghoritmHelper.Swap(ref a, ref b);
                }
                b -= a;
            }
            return a;
        }
    }
}