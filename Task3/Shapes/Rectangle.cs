using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : IShape, IMaterial
    {
        private double firstSide;

        private double secondSide;

        protected Color color;

        public Rectangle(double firstSide, double secondSide)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
        }

        public double Area()
        {

            return firstSide*secondSide;
        }

        public double Perimeter()
        {
            return 2*(firstSide+secondSide);
        }

        public Color GetColor()
        {
            return color;
        }
    }
}
