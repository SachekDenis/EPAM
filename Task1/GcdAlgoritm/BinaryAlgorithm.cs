using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Implementation of the binary Euclidean algorithm for computing GCD
    /// </summary>
    public class BinaryAlgorithm : IGcdCalculating
    {
        /// <summary>
        /// Finding the GCD of two numbers with the binary Euclidean algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD of two numbers</returns>
        public int CalculateGcd(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == 1 || b == 1)
                return 1;

            //If the numbers are negative, then the GCD is calculated from their absolute value.
            if (a < 0)
                a = Math.Abs(a);
            if (b < 0)
                b = Math.Abs(b);

            // shift - the largest power of two divided by a and b
            int shift = 0;
            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            // Divide a by two until a becomes odd
            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                // If b is even, remove all factors 2 in b
                while ((b & 1) == 0)
                    b >>= 1;

                /* a and b are now odd.
                   if you need to swap a and b,
                   if necessary to satisfy the condition a <= b */
                if (a > b)
                    AlghoritmHelper.Swap(ref a, ref b);

                b -= a;
            } while (b != 0);

            // Restore degree a
            return a << shift;
        }
    }
}