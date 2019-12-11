using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    /// <summary>
    /// Interface IShape
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns>Area.</returns>
        double GetArea();
        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        /// <returns>Perimeter.</returns>
        double GetPerimeter();
    }
}