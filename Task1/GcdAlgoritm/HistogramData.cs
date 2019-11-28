using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Preparation of data for building a histogram of runtime algorithms
    /// </summary>
    public class HistogramData
    {

        /// <summary>
        /// Finding the execution time of the GCD calculation algorithms
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="euclideanAlgorithmTime">Euclidean algorithm execution time</param>
        /// <param name="binaryAlgorithmTime">Binary algorithm execution time</param>
        public int GetGcdCalculationTime(int a, int b, ref TimeSpan euclideanAlgorithmTime, ref TimeSpan binaryAlgorithmTime)
        {
            CalculateGcd(a, b, ref euclideanAlgorithmTime, new EuclideanAlgorithm());
            return CalculateGcd(a, b, ref binaryAlgorithmTime, new BinaryAlgorithm());
        }

        /// <summary>
        /// Counting the execution time of the algorithm for calculating the GCD
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="timeOfCalculation">Time of calculation</param>
        /// <param name="alghoritm">GCD calculation algorithm</param>
        /// <returns></returns>
        public int CalculateGcd(int a, int b, ref TimeSpan timeOfCalculation, IGcdCalculating alghoritm)
        {
            if (alghoritm is null)
            {
                throw new ArgumentNullException(nameof(alghoritm));
            }

            Stopwatch time = new Stopwatch();

            time.Start();
            int gcd = alghoritm.CalculateGcd(a, b);
            time.Stop();

            timeOfCalculation = time.Elapsed;

            return gcd;
        }
    }
}