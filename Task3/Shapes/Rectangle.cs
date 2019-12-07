using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Rectangle : IShape, IMaterial
    {
        protected double firstSide;

        protected double secondSide;

        protected Color color;

        public double FirstSide { get => firstSide; }

        public double SecondSide { get => secondSide; }

        public Rectangle(double firstSide, double secondSide)
        {
            if (firstSide < 0 || secondSide < 0)
            {
                throw new ArgumentException("side cant be negative");
            }
            this.firstSide = firstSide;
            this.secondSide = secondSide;
        }

        public Rectangle(double firstSide, double secondSide, IShape shape) : this(firstSide, secondSide)
        {
            if (this.Area() >= shape.Area())
            {
                this.firstSide = 0;
                this.secondSide = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        public Rectangle(double firstSide, double secondSide, Color color) : this(firstSide, secondSide)
        {
            this.color = color;
        }

        public double Area()
        {

            return firstSide * secondSide;
        }

        public double Perimeter()
        {
            return 2 * (firstSide + secondSide);
        }

        public Color GetColor()
        {
            return color;
        }
    }
}
