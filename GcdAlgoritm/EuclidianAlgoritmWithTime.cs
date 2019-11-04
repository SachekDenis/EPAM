using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    public class EuclideanAlgorithmWithTime:EuclideanAlgorithm
    {
        public int CalculateGcd(int a, int b, ref TimeSpan timeOfCalculation)
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            int gcd = CalculateGcd(a, b);
            time.Stop();

            timeOfCalculation = time.Elapsed;

            return gcd;
        }
    }
}
