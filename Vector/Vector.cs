using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorProject
{
    /// <summary>
    /// Класс для работы с трехмерными векторами
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Трехмерный вектор реализуется с помощью массива
        /// </summary>
        private double[] vector = new double[3];
        /// <summary>
        /// Размерность вектора
        /// </summary>
        private readonly int dimension = 3;

        /// <summary>
        /// Создание вектора с помощью массива координат
        /// </summary>
        /// <param name="vector">Массив координат</param>
        public Vector(double[] vector)
        {
            if (vector != null && vector.Length == dimension)
                this.vector = vector;
            else
            {
                if (vector == null)
                    throw new ArgumentNullException(nameof(vector));
                else
                    throw new IndexOutOfRangeException("Invalid size of array.It must be 3");
            }

        }

        /// <summary>
        /// Создание вектора с помощью координат
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата/param>
        /// <param name="z">z координата</param>
        public Vector(double x, double y, double z)
        {
            vector[0] = x;
            vector[1] = y;
            vector[2] = z;
        }

        /// <summary>
        /// Доступ к произвольной координате вектора
        /// </summary>
        /// <param name="index">индекс координаты</param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < dimension)
                    return vector[index];
                else
                    throw new IndexOutOfRangeException("Invalid index of coordinate in vector.");
            }
            set
            {
                if (index >= 0 && index < dimension)
                    vector[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index of coordinate in vector.");
            }
        }

        /// <summary>
        /// Сложение векторов путем сложения соответствующих координат
        /// </summary>
        /// <param name="vector1">первый вектор</param>
        /// <param name="vector2">второй вектор</param>
        /// <returns>Новый вектор</returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement + secondVectorElement).ToArray());
        }

        /// <summary>
        /// Сложение векторов путем вычитания соответствующих координат
        /// </summary>
        /// <param name="vector1">первый вектор</param>
        /// <param name="vector2">второй вектор</param>
        /// <returns>Новый вектор</returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement - secondVectorElement).ToArray());
        }

        /// <summary>
        /// Скалярное умножение векторов
        /// </summary>
        /// <param name="vector1">первый вектор</param>
        /// <param name="vector2">второй вектор</param>
        /// <returns>Новый вектор</returns>
        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement * secondVectorElement).Sum();
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="vector1">Первый вектор</param>
        /// <param name="number">Число</param>
        /// <returns>Новый вектор</returns>
        public static Vector operator *(Vector vector1, double number)
        {
            return new Vector(vector1.vector.Select(e => e * number).ToArray());
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="vector1">Первый вектор</param>
        /// <param name="number">Число</param>
        /// <returns>Новый вектор</returns>
        public static Vector operator *(double number, Vector vector1)
        {
            return vector1*number;
        }


        /// <summary>
        /// Сравнение векторов
        /// </summary>
        /// <param name="obj">Второй вектор</param>
        /// <returns>Результат сравнения векторов</returns>
        public override bool Equals(object obj)
        {
            return obj is Vector vector && this.vector.SequenceEqual(vector.vector);
        }
    }
}
