using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    class BinaryGcdAlgorithm:EuclideanAlgorithm
    {
        public int CalculateBinaryGcd(int a, int b, ref TimeSpan timeOfCalculation)
        {

            Stopwatch time = new Stopwatch();

            time.Start();
           
            time.Stop();
            timeOfCalculation = time.Elapsed;
            /* restore common factors of 2 */
            return a =0;
        }
    }
}
