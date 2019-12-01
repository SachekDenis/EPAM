using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class PaperSquare : Square,IPaper
    {
        public PaperSquare(double side) : base(side)
        {}

        public void Paint(Color color)
        {

            if (color == Color.none)
                this.color = color;
            else
                throw new UnableToPaintExeption("Unable to paint shape more then one time");

        }
    }
}
