using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    public class GcdAlgorithmMultipleNumbers
    {
        public GcdAlgorithmMultipleNumbers(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        private IGcdCalculating Alghoritm { get; set; }

        /// <summary>
        /// Вычисление НОД трех целых чисел
        /// </summary>
        /// <returns>НОД трех целых чисел</returns>
        public int CalculateGcd(int a, int b, int c)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            return Alghoritm.CalculateGcd(gcdOfFirstPair, c);
        }

        /// <summary>
        /// Вычисление НОД четырех чисел
        /// </summary>
        /// <returns>НОД четырех чисел</returns>
        public int CalculateGcd(int a, int b, int c, int d)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            int gcdOfSecondPair = Alghoritm.CalculateGcd(gcdOfFirstPair, c);
            return Alghoritm.CalculateGcd(gcdOfSecondPair, d);
        }

        /// <summary>
        /// Вычисление НОД пяти чисел
        /// </summary>
        /// <returns>НОД пяти чисел</returns>
        public int CalculateGcd(int a, int b, int c, int d, int e)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            int gcdOfSecondPair = Alghoritm.CalculateGcd(gcdOfFirstPair, c);
            int gcdOfThirdPair = Alghoritm.CalculateGcd(gcdOfSecondPair, c);
            return Alghoritm.CalculateGcd(gcdOfThirdPair, d);
        }
    }
}