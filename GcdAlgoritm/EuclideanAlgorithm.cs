using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Реализация алгоритма Евклида для вычисления НОД
    /// </summary>
    public class EuclideanAlgorithm : IGcdCalculating
    {
        /// <summary>
        /// Алгоритм Евклида для вычисления НОД двух целых чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД двух целых чисел</returns>
        public int CalculateGcd(int a, int b)
        {
            // Если одно число равно нулю, то другое и будет НОД
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            //Процесс повторяется, пока числа не станут равными.
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