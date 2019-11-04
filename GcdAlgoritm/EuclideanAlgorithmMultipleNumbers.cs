using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    class EuclideanAlgorithmMultipleNumbers:EuclideanAlgorithm
    {
        /// <summary>
        /// Алгоритм Евклида для вычисления НОД трех целых чисел
        /// </summary>
        /// <returns>НОД трех целых чисел</returns>
        public int CalculateGcd(int a, int b, int c)
        {
            int gcdOfFirstPair = CalculateGcd(a, b);
            return CalculateGcd(gcdOfFirstPair, c);
        }

        /// <summary>
        /// Алгоритм Евклида для вычисления НОД четырех чисел
        /// </summary>
        /// <returns>НОД четырех чисел</returns>
        public int CalculateGcd(int a, int b, int c,int d)
        {
            int gcdOfFirstPair = CalculateGcd(a, b);
            int gcdOfSecondPair = CalculateGcd(gcdOfFirstPair, c);
            return CalculateGcd(gcdOfSecondPair, d);
        }

        /// <summary>
        /// Алгоритм Евклида для вычисления НОД пяти чисел
        /// </summary>
        /// <returns>НОД пяти чисел</returns>
        public int CalculateGcd(int a, int b, int c, int d, int e)
        {
            int gcdOfFirstPair = CalculateGcd(a, b);
            int gcdOfSecondPair = CalculateGcd(gcdOfFirstPair, c);
            int gcdOfThirdPair = CalculateGcd(gcdOfSecondPair, c);
            return CalculateGcd(gcdOfThirdPair, d);
        }
    }
}
