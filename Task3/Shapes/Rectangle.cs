using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class Rectangle.
    /// Implements the <see cref="Shapes.IShape" />
    /// Implements the <see cref="Shapes.IMaterial" />
    /// </summary>
    /// <seealso cref="Shapes.IShape" />
    /// <seealso cref="Shapes.IMaterial" />
    public abstract class Rectangle : IShape, IMaterial
    {
        /// <summary>
        /// The first side
        /// </summary>
        protected double _firstSide;

        /// <summary>
        /// The second side
        /// </summary>
        protected double _secondSide;

        /// <summary>
        /// The color
        /// </summary>
        protected Color _color;

        /// <summary>
        /// Gets the first side.
        /// </summary>
        /// <value>The first side.</value>
        public double FirstSide { get => _firstSide; }

        /// <summary>
        /// Gets the second side.
        /// </summary>
        /// <value>The second side.</value>
        public double SecondSide { get => _secondSide; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <exception cref="ArgumentException">Side cant be negative</exception>
        public Rectangle(double firstSide, double secondSide)
        {
            if (firstSide <= 0 || secondSide <= 0)
            {
                throw new ArgumentException("Side cant be negative");
            }
            this._firstSide = firstSide;
            this._secondSide = secondSide;
            _color = Color.none;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="shape">The shape.</param>
        /// <exception cref="UnableToCutShapeException">Size of shape is too small</exception>
        public Rectangle(double firstSide, double secondSide, IShape shape) : this(firstSide, secondSide)
        {
            if (this.GetArea() >= shape.GetArea())
            {
                this._firstSide = 0;
                this._secondSide = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="color">The color.</param>
        public Rectangle(double firstSide, double secondSide, Color color) : this(firstSide, secondSide)
        {
            this._color = color;
        }

        /// <summary>
        /// Get area of a rectangle.
        /// </summary>
        /// <returns>Area of a rectangle.</returns>
        public double GetArea()
        {

            return _firstSide * _secondSide;
        }

        /// <summary>
        /// Get perimeter of a rectangle.
        /// </summary>
        /// <returns>Perimeter of a rectangle.</returns>
        public double GetPerimeter()
        {
            return 2 * (_firstSide + _secondSide);
        }

        /// <summary>
        /// Get color of shape.
        /// </summary>
        /// <returns>Color of a shape.</returns>
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
            return obj is Rectangle rectangle &&
                   _firstSide == rectangle._firstSide &&
                   _secondSide == rectangle._secondSide &&
                   _color == rectangle._color &&
                   FirstSide == rectangle.FirstSide &&
                   SecondSide == rectangle.SecondSide;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = -106139944;
            hashCode = hashCode * -1521134295 + _firstSide.GetHashCode();
            hashCode = hashCode * -1521134295 + _secondSide.GetHashCode();
            hashCode = hashCode * -1521134295 + _color.GetHashCode();
            hashCode = hashCode * -1521134295 + FirstSide.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondSide.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("Rectangle, firstSide = {0}, second side = {1}, color = {2}", _firstSide, _secondSide, _color);
        }

    }
}
