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

        public Vector(double x, double y, double z)
        {
            vector[0] = x;
            vector[1] = y;
            vector[2] = z;
        }

        public double this[int index]
        {
            get
            {
                return vector[index];
            }
            set
            {
                vector[index] = value;
            }
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement + secondVectorElement).ToArray());
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement - secondVectorElement).ToArray());
        }

        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement * secondVectorElement).Sum();
        }

        public static double operator *(Vector vector1, double number)
        {
            return vector1.vector.Select(e=>e*number).Sum();
        }

        public override bool Equals(object obj)
        {
            return obj is Vector vector && this.vector.SequenceEqual(vector.vector);
        }
    }
}
