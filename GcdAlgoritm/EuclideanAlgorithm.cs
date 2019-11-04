using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    class EuclideanAlgorithm
    {
        /// <summary>
        /// Алгоритм Евклида для вычисления НОД двух целых чисел
        /// </summary>
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
                    Swap(ref a, ref b);
                }
                b -= a;
            }
            return a;
        }


        /// <summary>
        /// Обмен двух чисел методом "Трех стаканов"
        /// </summary>
        protected static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }
}
