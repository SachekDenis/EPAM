using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Counting the execution time of any algorithm for extracting GCD
    /// </summary>
    public class GcdCalculatingWithTime
    {
        /// <summary>
        /// Passing to the constructor an algorithm for which you want to calculate the execution time
        /// </summary>
        /// <param name="alghoritm">GCD calculation algorithm</param>
        public GcdCalculatingWithTime(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        /// <summary>
        /// GCD calculation algorithm
        /// </summary>
        private IGcdCalculating Alghoritm { get; set; }

        /// <summary>
        /// Counting the execution time of the algorithm for calculating the GCD
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="timeOfCalculation">Time of calculation</param>
        /// <returns></returns>
        public int CalculateGcd(int a, int b, ref TimeSpan timeOfCalculation)
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            int gcd = Alghoritm.CalculateGcd(a, b);
            time.Stop();

            timeOfCalculation = time.Elapsed;

            return gcd;
        }
    }
}