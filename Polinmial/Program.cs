using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinmial
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomial polinomial1 = new Polinomial(new double[]{1,2,3,4});
            Polinomial polinomial2 = new Polinomial(new double[]{1,2,3});
            var rk = polinomial1+polinomial2;
        }
    }
}
