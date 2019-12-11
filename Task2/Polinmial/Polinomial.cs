using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinmial
{
    /// <summary>
    /// Class of polinomial
    /// </summary>
    public class Polinomial
    {
        /// <summary>
        /// Polynomial is stored as an array of coefficients in increasing order of degrees
        /// </summary>
        private double[] coefficients;

        /// <summary>
        /// Polynomial degree
        /// </summary>
        private int degree;

        /// <summary>
        /// Polynomial degree
        /// </summary>
        public int Degree { get => degree;private set => degree = value; }


        /// <summary>
        /// Creating a polynomial from an array of coefficients in increasing order of degrees
        /// </summary>
        /// <param name="coefficients">Array of coefficients</param>
        public Polinomial(double[] coefficients)
        {
            if (coefficients != null && coefficients.Length > 0)
            {
                this.coefficients = coefficients;
                degree = coefficients.Length - 1;
            }
            else
                throw new ArgumentNullException(nameof(coefficients));
        }


        /// <summary>
        /// Indexer to access to coefficients
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Coefficient</returns>
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


        /// <summary>
        /// Sum of two polynomials
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <returns>The new polynomial representing the sum</returns>
        public static Polinomial operator +(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return PolinomialZipOperation(firstPolinomial, secondPolinomial, (first, second) => first + second);
        }

        /// <summary>
        /// Difference of two polynomials
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <returns>The new polynomial representing the difference</returns>
        public static Polinomial operator -(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return PolinomialZipOperation(firstPolinomial, secondPolinomial, (first, second) => first - second);
        }


        /// <summary>
        /// Operation on the corresponding coefficients of both polynomials
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <param name="selector">Operation</param>
        /// <returns>New polynomial representing the result of a operation</returns>
        private static Polinomial PolinomialZipOperation(Polinomial firstPolinomial, Polinomial secondPolinomial, Func<double, double, double> selector)
        {
            //Residual elements of a larger collection
            IEnumerable<double> tale;
            if (firstPolinomial.coefficients.Length > secondPolinomial.coefficients.Length)
                tale = firstPolinomial.coefficients.Skip(secondPolinomial.coefficients.Length);
            else
                tale = secondPolinomial.coefficients.Skip(firstPolinomial.coefficients.Length);
            return new Polinomial(firstPolinomial.coefficients.Zip(secondPolinomial.coefficients, selector).
                Concat(tale).ToArray());
        }


        /// <summary>
        /// Multiplication of a polynomial by a polynomial
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <returns>New polynomial representing the result of a multiplication</returns>
        public static Polinomial operator *(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            double[] newCoefficients = new double[firstPolinomial.degree + secondPolinomial.degree + 1];
            for (int i = 0; i < firstPolinomial.coefficients.Length; i++)
            {
                for (int j = 0; j < secondPolinomial.coefficients.Length; j++)
                {
                    newCoefficients[i + j] += firstPolinomial.coefficients[i] * secondPolinomial.coefficients[j];
                }
            }
            return new Polinomial(newCoefficients);
        }


        /// <summary>
        /// Multiplication of a polynomial by a number
        /// </summary>
        /// <param name="polinomial">Polynomial</param>
        /// <param name="number">Number</param>
        /// <returns>New polynomial representing the result of a multiplication by a number</returns>
        public static Polinomial operator *(Polinomial polinomial, double number)
        {
            return new Polinomial(polinomial.coefficients.Select(e => e * number).ToArray());
        }


        /// <summary>
        /// Multiplication of a polynomial by a number
        /// </summary>
        /// <param name="polinomial">Polynomial</param>
        /// <param name="number">Number</param>
        /// <returns>New polynomial representing the result of a multiplication by a number</returns>
        public static Polinomial operator *(double number, Polinomial polinomial)
        {
            return polinomial * number;
        }

        /// <summary>
        /// Division of polynomials (remainder is discarded)
        /// </summary>
        /// <param name="firstPolinomial">First polinomial</param>
        /// <param name="secondPolinomial">Second polinomial</param>
        /// <returns>Quotient ща division of polynomials, null in case of division of a polynomial with a lower degree by a polynomial with a greater</returns>
        public static Polinomial operator /(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            //Division of polinomials valid only in case of division of a polynomial with a greater degree by a polynomial with a lower, because of remainder is discarded
            if(firstPolinomial.Degree<secondPolinomial.Degree)
                return null;

            //Divisioan on null prohibited
            if(secondPolinomial.Degree == 0 && secondPolinomial.coefficients[0] == 0)
            {
                return null;
            }

            // Flip arrays of coefficients to execute the division algorithm
            double[] firstPolinomialsCoefficients = firstPolinomial.coefficients.Reverse().ToArray();
            double[] secondPolinomialsCoefficients = secondPolinomial.coefficients.Reverse().ToArray();

            int currentDegree = firstPolinomial.degree;

            List<double> solutionCoefficients = new List<double>();
            //Using to store intermediate coefficients
            List<double> tempCoefficients = new List<double>();

            tempCoefficients.AddRange(firstPolinomialsCoefficients);

            //Number of iterations is equal to the degree of the result
            for (int i = 0; i <= firstPolinomialsCoefficients.Length - secondPolinomialsCoefficients.Length; i++)
            {
                if (currentDegree > 0)
                {
                    solutionCoefficients.Add(tempCoefficients[i] / secondPolinomialsCoefficients[0]);
                    for (int j = 0; j < secondPolinomialsCoefficients.Length; j++)
                    {
                        tempCoefficients[i + j] = tempCoefficients[i + j] - (solutionCoefficients[i] * secondPolinomialsCoefficients[j]);
                    }
                    currentDegree--;
                }
                else
                {
                    solutionCoefficients.Add(tempCoefficients[i] / secondPolinomialsCoefficients[0]);
                }
            }

            return new Polinomial(solutionCoefficients.AsEnumerable().Reverse().ToArray());
        }

        /// <summary>
        /// Checking polynomials for equality
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <returns>Equality test result</returns>
        public static bool operator ==(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return Equals(firstPolinomial, secondPolinomial);
        }


        /// <summary>
        /// Checking polynomials for inequality
        /// </summary>
        /// <param name="firstPolinomial">First polynomial</param>
        /// <param name="secondPolinomial">Second polynomial</param>
        /// <returns>Inequality test result</returns>
        public static bool operator !=(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return Equals(firstPolinomial, secondPolinomial);
        }

        /// <summary>
        /// Checking polynomials for equality
        /// </summary>
        /// <param name="obj">Comparison object</param>
        /// <returns>Equality test result</returns>
        public override bool Equals(object obj)
        {
            //Polinomials equals then their coefficients equals
            return obj is Polinomial polinomial && this.coefficients.SequenceEqual(polinomial.coefficients);
        }
    }
}
