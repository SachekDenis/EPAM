﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : IShape, IMaterial
    {
        private double radius;

        protected Color color;

        public Circle(double radius)
        {
            this.radius = radius;
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
