using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    /// <summary>
    /// Класс для работы с трехмерными векторами
    /// </summary>
    class Vector
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
                if(vector == null)
                    throw new ArgumentNullException(nameof(vector));
                else
                    throw new IndexOutOfRangeException("Invalid size of array.It must be 3");
            }

        }

        public Vector(double a, double b, double c)
        {
            vector[0] = a;
            vector[1] = b;
            vector[2] = c;
        }

        public double this[int index]
        {
            get
            {
                return vector[index];
            }
            set
            {
                vector[index]=value;
            }
        }
    }
}
