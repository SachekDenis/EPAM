using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public class Circle:Shape
    {
        private double radius;

        public Circle(double radius)
        {
            IPaper square = new PaperSquare(2);
            square.
            this.radius = radius;
        }

        public override double Area()
        {
            return radius*radius*Math.PI;
        }

        public override double Perimeter()
        {
            return 2*radius*Math.PI;
        }
    }
}