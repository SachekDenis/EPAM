using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public abstract class Square : IShape, IMaterial
    {
        private double side;

        protected Color color;

        public Square(double side)
        {
            this.side = side;
        }

        public Square(double side, IShape shape)
        {
            this.side = side;
            if(this.Area() >= shape.Area())
            {
                this.side = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        public double Area()
        {

            return side * side;
        }

        public double Perimeter()
        {
            return side * 4;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}