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
        /// <returns>System.Double.</returns>
        double GetArea();
        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        /// <returns>System.Double.</returns>
        double GetPerimeter();
    }
}