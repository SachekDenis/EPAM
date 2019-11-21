﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinmial
{
    public class Polinomial
    {
        /// <summary>
        /// Многочлен хранится как массив коэффициентов в порядке возрастания степеней
        /// </summary>
        private double[] coefficients;

        /// <summary>
        /// Степень многочлена
        /// </summary>
        private int degree;

        public int Degree { get => degree; set => degree = value; }


        /// <summary>
        /// Создание многочлена из массива коэффициентов в порядке возрастания степеней
        /// </summary>
        /// <param name="coefficients">Массив коэфициентов</param>
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


        /// <summary>
        /// Сумма двух многочленов
        /// </summary>
        /// <param name="firstPolinomial">Первый многочлен</param>
        /// <param name="secondPolinomial">Второй многочлен</param>
        /// <returns>Новый многочлен, прелставляющий собой сумму</returns>
        public static Polinomial operator +(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            CheckNull(firstPolinomial);
            CheckNull(secondPolinomial);
            return PolinomialZipOperation(firstPolinomial, secondPolinomial, (first, second) => first + second);
        }

        /// <summary>
        /// Разность двух многочленов
        /// </summary>
        /// <param name="firstPolinomial">Первый многочлен</param>
        /// <param name="secondPolinomial">Второй многочлен</param>
        /// <returns>Новый многочлен, прелставляющий собой разность</returns>
        public static Polinomial operator -(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            CheckNull(firstPolinomial);
            CheckNull(secondPolinomial);
            return PolinomialZipOperation(firstPolinomial, secondPolinomial, (first, second) => first - second);
        }


        /// <summary>
        /// Операция над соответствующими коэффициентами обоих многочленов
        /// </summary>
        /// <param name="firstPolinomial">Первый многочлен</param>
        /// <param name="secondPolinomial">Второй многочлен</param>
        /// <param name="selector">Операция</param>
        /// <returns>>Новый многочлен, представляюший собой результат операции</returns>
        private static Polinomial PolinomialZipOperation(Polinomial firstPolinomial, Polinomial secondPolinomial, Func<double, double, double> selector)
        {
            //Остаточные элементы большей коллекции
            IEnumerable<double> tale;
            if (firstPolinomial.coefficients.Length > secondPolinomial.coefficients.Length)
                tale = firstPolinomial.coefficients.Skip(secondPolinomial.coefficients.Length);
            else
                tale = secondPolinomial.coefficients.Skip(firstPolinomial.coefficients.Length);
            return new Polinomial(firstPolinomial.coefficients.Zip(secondPolinomial.coefficients, selector).
                Concat(tale).ToArray());
        }


        /// <summary>
        /// Умножение многочлена на многочлен
        /// </summary>
        /// <param name="firstPolinomial">Первый многочлен</param>
        /// <param name="secondPolinomial">Второй многочлен</param>
        /// <returns>Новый многочлен, представляюший собой результат умножения</returns>
        public static Polinomial operator *(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            CheckNull(firstPolinomial);
            CheckNull(secondPolinomial);
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
        /// Умножение многочлена на число
        /// </summary>
        /// <param name="polinomial">Многочлен</param>
        /// <param name="number">Число</param>
        /// <returns>Новый многочлен, представляюший собой результат умножения на число</returns>
        public static Polinomial operator *(Polinomial polinomial, double number)
        {
            CheckNull(polinomial);
            return new Polinomial(polinomial.coefficients.Select(e => e * number).ToArray());
        }


        /// <summary>
        /// Умножение многочлена на число
        /// </summary>
        /// <param name="polinomial">Многочлен</param>
        /// <param name="number">Число</param>
        /// <returns>Новый многочлен, представляюший собой результат умножения на число</returns>
        public static Polinomial operator *(double number, Polinomial polinomial)
        {
            CheckNull(polinomial);
            return polinomial * number;
        }

        public static bool operator ==(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return Equals(firstPolinomial, secondPolinomial);
        }

        public static bool operator !=(Polinomial firstPolinomial, Polinomial secondPolinomial)
        {
            return Equals(firstPolinomial, secondPolinomial);
        }

        public override bool Equals(object obj)
        {
            return obj is Polinomial polinomial && this.coefficients.SequenceEqual(polinomial.coefficients);
        }

        private static void CheckNull(Polinomial polinomial)
        {
            if (polinomial == null)
            {
                throw new ArgumentNullException(nameof(polinomial));
            }
        }
    }
}
