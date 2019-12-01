using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public abstract class Square : IShape,IMaterial
    {
        private double side;

        protected Color color;

        public Square(double side)
        {
            this.side = side;
        }

        public double Area()
        {
            
            return side*side;
        }

        public double Perimeter()
        {
            return side*4;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}