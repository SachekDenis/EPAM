using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class PaperRectangle: Rectangle,IPaper
    {
        public PaperRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        public PaperRectangle(double firstSide, double secondSide, IShape shape) : base(firstSide, secondSide, shape)
        {
            if (!(shape is IPaper))
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

        public PaperRectangle(double firstSide, double secondSide, Color color) : base(firstSide, secondSide, color)
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
            return string.Concat(base.ToString(), "material = paper");
        }
    }
}
