using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Подсчет времени выполнения любого алгоритма вычиления НОД
    /// </summary>
    public class GcdCalculatingWithTime
    {
        /// <summary>
        /// Передача в конструктор алгоритма, для которого требуется подсчитать время выполнения
        /// </summary>
        /// <param name="alghoritm">Алгоритм вычисления НОД</param>
        public GcdCalculatingWithTime(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        /// <summary>
        /// Алгоритм вычисления НОД
        /// </summary>
        private IGcdCalculating Alghoritm { get; set; }

        /// <summary>
        /// Подсчет времени выполнения алгоритма вычисления НОД
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="timeOfCalculation">Время выполнения</param>
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