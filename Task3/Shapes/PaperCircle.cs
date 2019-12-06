using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class PaperCircle:Circle,IPaper
    {
        public PaperCircle(double radius) : base(radius)
        {
        }

        public PaperCircle(double radius, IShape shape) : base(radius, shape)
        {
            if (!(shape is IPaper))
            {
                this.radius = 0;
                throw new UnableToCutShapeException("Cant cut from another material");
            }
            else
            {
                this.color = (shape as IMaterial).GetColor();
            }
        }

        public PaperCircle(double radius, Color color) : base(radius, color)
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

        public void Paint(Color color)
        {

            if (color == Color.none)
                this.color = color;
            else
                throw new UnableToPaintExeption("Unable to paint shape more then one time");

        }

        public override string ToString()
        {
            return string.Concat(base.ToString(),"material = paper");
        }
    }
}
