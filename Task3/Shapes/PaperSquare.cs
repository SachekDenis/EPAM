using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class PaperSquare : Square, IPaper
    {
        public PaperSquare(double side) : base(side)
        { }

        public PaperSquare(double side, Color color) : base(side, color)
        {
        }

        public PaperSquare(double side, IShape shape) : base(side, shape)
        {
            if (!(shape is IPaper))
            {
                this.Side = 0;
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
