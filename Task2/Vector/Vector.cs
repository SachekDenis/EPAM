using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorProject
{
    /// <summary>
    /// Class for working with three-dimensional vectors
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Three-dimensional vector is implemented using an array
        /// </summary>
        private double[] vector = new double[3];
        /// <summary>
        /// Vector dimension
        /// </summary>
        private readonly int dimension = 3;

        /// <summary>
        /// reating a vector using an array of coordinates
        /// </summary>
        /// <param name="vector">Array of coordinates</param>
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
        /// Creating a vector using coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Vector(double x, double y, double z)
        {
            vector[0] = x;
            vector[1] = y;
            vector[2] = z;
        }

        /// <summary>
        /// Access to arbitrary vector coordinate
        /// </summary>
        /// <param name="index">Coordinate index</param>
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
        /// Addition of vectors by adding the corresponding coordinates
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector</returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement + secondVectorElement).ToArray());
        }

        /// <summary>
        /// Addition of vectors by subtracting the corresponding coordinates
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector</returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement - secondVectorElement).ToArray());
        }

        /// <summary>
        /// Scalar vector multiplication
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector</returns>
        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1.vector.Zip(vector2.vector, (firstVectorElement, secondVectorElement) => firstVectorElement * secondVectorElement).Sum();
        }

        /// <summary>
        /// Multiplication of a vector by a number
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="number">Number</param>
        /// <returns>New vector</returns>
        public static Vector operator *(Vector vector, double number)
        {
            return new Vector(vector.vector.Select(e => e * number).ToArray());
        }

        /// <summary>
        /// Multiplication of a vector by a number
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="number">Number</param>
        /// <returns>New vector</returns>
        public static Vector operator *(double number, Vector vector)
        {
            return vector*number;
        }


        /// <summary>
        /// Division of a vector by a number
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="number">Number</param>
        /// <returns>New vector</returns>
        public static Vector operator /(Vector vector1, double number)
        {
            return new Vector(vector1.vector.Select(e => e / number).ToArray());
        }

        /// <summary>
        /// Checking vectors for equality
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>Equality test Result</returns>
        public static bool operator ==(Vector vector1,Vector vector2)
        {
            return vector1.Equals(vector2);
        }

        /// <summary>
        /// Checking vectors for inequality
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>Inequality test Result</returns>
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return vector1.Equals(vector2);
        }

        /// <summary>
        /// Vector comparison
        /// </summary>
        /// <param name="obj">Second vector</param>
        /// <returns>Vector comparison result</returns>
        public override bool Equals(object obj)
        {
            return obj is Vector vector && this.vector.SequenceEqual(vector.vector);
        }
    }
}
