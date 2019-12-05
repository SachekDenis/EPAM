using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class PaperCircle:Circle,IPaper
    {
        public PaperCircle(double radius) : base(radius)
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
