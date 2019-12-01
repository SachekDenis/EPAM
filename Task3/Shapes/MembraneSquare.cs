using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class MembraneSquare : Square, IMembrane
    {
        public MembraneSquare(double side) : base(side)
        {}
    }
}
