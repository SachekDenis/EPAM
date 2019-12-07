using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class Circle.
    /// Implements the <see cref="Shapes.IShape" />
    /// Implements the <see cref="Shapes.IMaterial" />
    /// </summary>
    /// <seealso cref="Shapes.IShape" />
    /// <seealso cref="Shapes.IMaterial" />
    public abstract class Circle : IShape, IMaterial
    {
        /// <summary>
        /// Cadius of a circle
        /// </summary>
        protected double _radius;

        /// <summary>
        /// Color of a shape
        /// </summary>
        protected Color _color;

        /// <summary>
        /// Get color of a circle
        /// </summary>
        /// <value>The radius.</value>
        public double Radius { get => _radius; }

        /// <summary>
        /// Create circle by radius
        /// </summary>
        /// <param name="radius">Radius of circle</param>
        /// <exception cref="ArgumentException">Radius cant be negative</exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius cant be negative");
            this._radius = radius;
        }

        /// <summary>
        /// Create circle from another shape
        /// </summary>
        /// <param name="radius">Radius of circle</param>
        /// <param name="shape">Another shape</param>
        /// <exception cref="UnableToCutShapeException">Size of shape is too small</exception>
        public Circle(double radius, IShape shape):this(radius)
        {
            this._radius = radius;
            if (this.GetArea() >= shape.GetArea())
            {
                this._radius = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        /// <summary>
        /// Create circle by color
        /// </summary>
        /// <param name="radius">Radius of circle</param>
        /// <param name="color">Color</param>
        public Circle(double radius, Color color) : this(radius)
        {
            this._color = color;
        }

        /// <summary>
        /// Get area of circle
        /// </summary>
        /// <returns>Area of circle</returns>
        public double GetArea()
        {

            return Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Get perimeter of circle
        /// </summary>
        /// <returns>Perimeter of circle</returns>
        public double GetPerimeter()
        {
            return Math.PI * _radius / 2;
        }

        /// <summary>
        /// Get color of a circle
        /// </summary>
        /// <returns>Color of a circle</returns>
        public Color GetColor()
        {
            return _color;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is Circle circle &&
                   _radius == circle._radius &&
                   _color == circle._color &&
                   Radius == circle.Radius;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = -662471224;
            hashCode = hashCode * -1521134295 + _radius.GetHashCode();
            hashCode = hashCode * -1521134295 + _color.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("Circle, radius = {0}, color = {1}", _radius, _color);;
        }
    }
}
