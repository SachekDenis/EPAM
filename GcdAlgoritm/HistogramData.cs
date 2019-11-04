using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    public class HistogramData
    {
        /// <summary>
        /// Нахождение времени выполнения алгоритмов вычисления НОД
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="euclideanAlgorithmTime">Время выполнения алгоритма Евклида</param>
        /// <param name="binaryAlgorithmTime">Время выполнения бинарного алгоритма</param>
        public int GetGcdTime(int a, int b, ref TimeSpan euclideanAlgorithmTime, ref TimeSpan binaryAlgorithmTime)
        {
            GcdCalculatingWithTime euclidean = new GcdCalculatingWithTime(new EuclideanAlgorithm());
            GcdCalculatingWithTime binary = new GcdCalculatingWithTime(new BinaryAlgorithm());
            euclidean.CalculateGcd(a, b, ref euclideanAlgorithmTime);
            return binary.CalculateGcd(a, b, ref binaryAlgorithmTime);
        }
    }
}