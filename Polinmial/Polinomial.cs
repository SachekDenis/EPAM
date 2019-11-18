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
        /// Многочлен хранится как массив коэффициентов в порядке убывания степеней
        /// </summary>
        private double[] coefficients;

        /// <summary>
        /// Степень многочлена
        /// </summary>
        private int degree;

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
    }
}
