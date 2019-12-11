using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Class MembraneRectangle.
    /// Implements the <see cref="Shapes.Rectangle" />
    /// Implements the <see cref="Shapes.IMembrane" />
    /// </summary>
    /// <seealso cref="Shapes.Rectangle" />
    /// <seealso cref="Shapes.IMembrane" />
    public class MembraneRectangle : Rectangle, IMembrane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MembraneRectangle"/> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        public MembraneRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MembraneRectangle"/> class.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="shape">The shape.</param>
        /// <exception cref="UnableToCutShapeException">Cant cut from another material</exception>
        public MembraneRectangle(double firstSide, double secondSide, IShape shape) : base(firstSide, secondSide, shape)
        {
            if (!(shape is IMembrane))
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(base.ToString(), ", material = membrane");
        }
    }
}
