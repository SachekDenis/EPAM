using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Circle : IShape, IMaterial
    {
        private double radius;

        protected Color color;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public Circle(double radius, IShape shape)
        {
            this.radius = radius;
            if(this.Area() >= shape.Area())
            {
                this.radius = 0;
                throw new UnableToCutShapeException("Size of shape is too small");
            }
        }

        public double Area()
        {

            return Math.PI * radius * radius;
        }

        public double Perimeter()
        {
            return Math.PI * radius / 2;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}
