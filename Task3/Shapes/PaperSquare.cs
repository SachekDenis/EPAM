using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class PaperSquare.
    /// Implements the <see cref="Shapes.Square" />
    /// Implements the <see cref="Shapes.IPaper" />
    /// </summary>
    /// <seealso cref="Shapes.Square" />
    /// <seealso cref="Shapes.IPaper" />
    public class PaperSquare : Square, IPaper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaperSquare"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        public PaperSquare(double side) : base(side)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperSquare"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        public PaperSquare(double side, Color color) : base(side, color)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperSquare"/> class.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="shape">The shape.</param>
        /// <exception cref="UnableToCutShapeException">Cant cut from another material</exception>
        public PaperSquare(double side, IShape shape) : base(side, shape)
        {
            if (!(shape is IPaper))
            {
                this._side = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this._color = (shape as IMaterial).GetColor();
            }
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
