using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class PaperRectangle.
    /// Implements the <see cref="Shapes.Rectangle" />
    /// Implements the <see cref="Shapes.IPaper" />
    /// </summary>
    /// <seealso cref="Shapes.Rectangle" />
    /// <seealso cref="Shapes.IPaper" />
    public class PaperRectangle: Rectangle,IPaper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaperRectangle"/> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        public PaperRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperRectangle"/> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="shape">The shape.</param>
        /// <exception cref="UnableToCutShapeException">Cant cut from another material</exception>
        public PaperRectangle(double firstSide, double secondSide, IShape shape) : base(firstSide, secondSide, shape)
        {
            if (!(shape is IPaper))
            {
                this._firstSide = 0;
                this._secondSide = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this._color = (shape as IMaterial).GetColor();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperRectangle"/> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="color">The color.</param>
        public PaperRectangle(double firstSide, double secondSide, Color color) : base(firstSide, secondSide, color)
        {
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Change color of a shape
        /// </summary>
        /// <param name="color">New color of a shape</param>
        /// <exception cref="UnableToPaintExeption">Unable to paint shape more then one time</exception>
        public void Paint(Color color)
        {
            if(color == Color.none)
                throw new UnableToPaintException("Unable to paint shape to none color");
            if (_color == Color.none)
                this._color = color;
            else
                throw new UnableToPaintException("Unable to paint shape more then one time");

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(base.ToString(), "material = paper");
        }
    }
}
