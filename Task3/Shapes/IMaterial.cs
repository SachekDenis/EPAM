using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Interface for material of a shape
    /// </summary>
    public interface IMaterial
    {
        /// <summary>
        /// Get color of shape
        /// </summary>
        /// <returns>Color of a shape</returns>
        Color GetColor();
    }
}
