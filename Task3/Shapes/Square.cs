using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public abstract class Square : IShape, IMaterial
    {
        protected double side;

        protected Color color;

        public double Side { get => side;}

        public Square(double side)
        {
            if(side < 0 )
                throw new ArgumentException("side cant be negetive");
            this.side = side;
        }

        public Square(double side, Color color):this(side)
        {
            this.color = color;
        }

        public Square(double side, IShape shape):this(side)
        {
            if (this.Area() >= shape.Area())
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

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   side == square.side &&
                   color == square.color;
        }

        public override int GetHashCode()
        {
            var hashCode = -689785498;
            hashCode = hashCode * -1521134295 + side.GetHashCode();
            hashCode = hashCode * -1521134295 + color.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("Square, side = {0}, color = {1}", Side, color);
        }
    }
}