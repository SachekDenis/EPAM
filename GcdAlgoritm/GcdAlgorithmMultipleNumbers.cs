using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Вычисление НОД нескольких чисел
    /// </summary>
    public class GcdAlgorithmMultipleNumbers
    {
        /// <summary>
        /// Передача алгоритма вычисления НОД
        /// </summary>
        /// <param name="alghoritm">Алгоритма вычисления НОД</param>
        public GcdAlgorithmMultipleNumbers(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        private IGcdCalculating Alghoritm { get; set; }

        /// <summary>
        /// Вычисление НОД трех целых чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns>НОД трех целых чисел</returns>
        public int CalculateGcd(int a, int b, int c)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            return Alghoritm.CalculateGcd(gcdOfFirstPair, c);
        }

        /// <summary>
        /// Вычисление НОД четырех чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <param name="d">Четвертое число</param>
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
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <param name="d">Четвертое число</param>
        /// <param name="e">Пятое число</param>
        /// <returns>НОД пяти чисел</returns>
        public int CalculateGcd(int a, int b, int c, int d, int e)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            int gcdOfSecondPair = Alghoritm.CalculateGcd(gcdOfFirstPair, c);
            int gcdOfThirdPair = Alghoritm.CalculateGcd(gcdOfSecondPair, d);
            return Alghoritm.CalculateGcd(gcdOfThirdPair, e);
        }
    }
}