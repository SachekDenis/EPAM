using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Вспомогательный класс для реализации алгоритмов
    /// </summary>
    internal class AlghoritmHelper
    {
        /// <summary>
        /// Обмен двух чисел методом "Трех стаканов"
        /// </summary>
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }
}