using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    /// <summary>
    /// Class Square.
    /// Implements the <see cref="Shapes.IShape" />
    /// Implements the <see cref="Shapes.IMaterial" />
    /// </summary>
    /// <seealso cref="Shapes.IShape" />
    /// <seealso cref="Shapes.IMaterial" />
    public abstract class Square : IShape, IMaterial
    {
        /// <summary>
        /// The side
        /// </summary>
        protected double _side;

        /// <summary>
        /// The color
        /// </summary>
        protected Color _color;

        /// <summary>
        /// Gets the side.
        /// </summary>
        /// <value>The side.</value>
        public double Side { get => _side;}

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <exception cref="ArgumentException">Side cant be negetive</exception>
        public Square(double side)
        {
            if(side <= 0 )
                throw new ArgumentException("Side cant be negetive");
            this._side = side;
            _color = Color.none;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        public Square(double side, Color color):this(side)
        {
            this._color = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="shape">The shape.</param>
        /// <exception cref="UnableToCutShapeException">Size of shape is too small</exception>
        public Square(double side, IShape shape):this(side)
        {
            if (this.GetArea() >= shape.GetArea())
            {
                this._side = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        /// <summary>
        /// Get area of a square.
        /// </summary>
        /// <returns>Area of a square.</returns>
        public double GetArea()
        {

            return _side * _side;
        }

        /// <summary>
        /// Get perimeters this instance.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetPerimeter()
        {
            return _side * 4;
        }

        /// <summary>
        /// Get color of shape
        /// </summary>
        /// <returns>Color of a shape</returns>
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
            return obj is Square square &&
                   _side == square._side &&
                   _color == square._color;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = -689785498;
            hashCode = hashCode * -1521134295 + _side.GetHashCode();
            hashCode = hashCode * -1521134295 + _color.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("Square, side = {0}, color = {1}", Side, _color);
        }
    }
}