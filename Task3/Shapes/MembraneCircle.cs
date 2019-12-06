using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class MembraneCircle : Circle, IMembrane
    {
        public MembraneCircle(double radius) : base(radius)
        {
        }

        public MembraneCircle(double radius, IShape shape) : base(radius, shape)
        {
            if (!(shape is IMembrane))
            {
                this.radius = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this.color = (shape as IMaterial).GetColor();
            }
        }

        public MembraneCircle(double radius, Color color) : base(radius, color)
        {
        }

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
