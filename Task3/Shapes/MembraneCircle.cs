﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class MembraneCircle : Circle, IMembrane
    {
        public MembraneCircle(double radius) : base(radius)
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

        public override string ToString()
        {
            return string.Concat(base.ToString(), "material = membrane");
        }
    }
}
