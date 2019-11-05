using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Реализация бинарного алгоритма Евклида для вычисления НОД
    /// </summary>
    public class BinaryAlgorithm : IGcdCalculating
    {
        /// <summary>
        /// Нахождение НОД двух чисел бинарным алгоритмом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="timeOfCalculation">Время выполнения рассчетов</param>
        /// <returns>НОД двух чисел</returns>
        public int CalculateGcd(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == 1 || b == 1)
                return 1;

            //Если числа отрицательны, то НОД вычисляется от их абсолютного значения
            if (a < 0)
                a = Math.Abs(a);
            if (b < 0)
                b = Math.Abs(b);

            // shift - наибольшая степень двойки, на которую делятся и a, и b
            int shift = 0;
            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            // Деление a на два, пока a не станет нечетным
            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                // Если b четно, удаляем все множители 2 в b
                while ((b & 1) == 0)
                    b >>= 1;

                /* a и b теперь нечетны.
                   Если нужно меняем местами a и b,
                   если это необходимо для выполнения условия a<=b */
                if (a > b)
                    AlghoritmHelper.Swap(ref a, ref b);

                b -= a;
            } while (b != 0);

            /* Восстанавливаем степень a*/
            return a << shift;
        }
    }
}