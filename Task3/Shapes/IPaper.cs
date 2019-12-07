using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Interface for paper material
    /// </summary>
    public interface IPaper:IMaterial
    {
        /// <summary>
        /// Change color of a shape
        /// </summary>
        /// <param name="color">New color of a shape</param>
        void Paint(Color color);
    }
}
