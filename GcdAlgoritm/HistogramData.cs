using System;
using System.Collections.Generic;
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
        /// <param name="binaryAlgorithmTime">Binary algorithm runtime</param>
        public int GetGcdCalculationTime(int a, int b, ref TimeSpan euclideanAlgorithmTime, ref TimeSpan binaryAlgorithmTime)
        {
            GcdCalculatingWithTime euclidean = new GcdCalculatingWithTime(new EuclideanAlgorithm());
            GcdCalculatingWithTime binary = new GcdCalculatingWithTime(new BinaryAlgorithm());
            euclidean.CalculateGcd(a, b, ref euclideanAlgorithmTime);
            return binary.CalculateGcd(a, b, ref binaryAlgorithmTime);
        }
    }
}