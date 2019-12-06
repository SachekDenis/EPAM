using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class MembraneSquare : Square, IMembrane
    {
        public MembraneSquare(double side) : base(side)
        {}

        public MembraneSquare(double side, IShape shape): base(side, shape)
        {
            if (!(shape is IMembrane))
            {
                this.side = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this.color = (shape as IMaterial).GetColor();
            }
        }

        public MembraneSquare(double side, Color color) : base(side, color)
        {}

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), "material = membrane");
        }
    }
}
