using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinmial
{
    class Polinomial
    {
        /// <summary>
        /// Многочлен хранится как массив коэффициентов в порядке возрастания степеней
        /// </summary>
        private double[] coefficients;

        /// <summary>
        /// Степень многочлена
        /// </summary>
        private int degree;


        /// <summary>
        /// Создание многочлена из массива коэффициентов в порядке возрастания степеней
        /// </summary>
        /// <param name="coefficients">Массив коэфициентов</param>
        public Polinomial(double[] coefficients)
        {
            if (coefficients != null && coefficients.Length > 0)
            { 
                this.coefficients = coefficients;
                degree = coefficients.Length-1;
            }
            else
                throw new ArgumentNullException(nameof(coefficients));
        }


        /// <summary>
        /// Индексатор для доступа к коэффициентам
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Коэффициент</returns>
        public double this[int index]
        {
            get
            {
                return coefficients[index];
            }
            set
            {
                coefficients[index] = value;
            }
        }

        public static Polinomial operator +(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            //Остаточные элементы большей коллекции
            IEnumerable<double> tale;
            if(firstPolinomial.coefficients.Length>secondPolinomial.coefficients.Length)
                tale = firstPolinomial.coefficients.Skip(secondPolinomial.coefficients.Length);
            else
                tale = secondPolinomial.coefficients.Skip(firstPolinomial.coefficients.Length);
            return new Polinomial(firstPolinomial.coefficients.Zip(secondPolinomial.coefficients,(first,second)=>first+second).
                Concat(tale).ToArray());
        }
    }
}
