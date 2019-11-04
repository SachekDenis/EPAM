using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    public class GcdCalculatingWithTime
    {
        public GcdCalculatingWithTime(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        private IGcdCalculating Alghoritm { get; set; }

        public int CalculateGcd(int a, int b, ref TimeSpan timeOfCalculation)
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            int gcd = Alghoritm.CalculateGcd(a, b);
            time.Stop();

            timeOfCalculation = time.Elapsed;

            return gcd;
        }
    }
}