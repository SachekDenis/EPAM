using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class MembraneRectangle : Rectangle, IMembrane
    {
        public MembraneRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        public MembraneRectangle(double firstSide, double secondSide, IShape shape) : base(firstSide, secondSide, shape)
        {
            if (!(shape is IMembrane))
            {
                this.firstSide = 0;
                this.secondSide = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this.color = (shape as IMaterial).GetColor();
            }
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
