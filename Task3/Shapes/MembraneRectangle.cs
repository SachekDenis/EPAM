using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class MembraneRectangle : Rectangle, IMembrane
    {
        public MembraneRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }
    }
}
