using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdAlgoritm
{
    /// <summary>
    /// Calculation of GCD of several numbers
    /// </summary>
    public class GcdAlgorithmMultipleNumbers
    {
        /// <summary>
        /// Transmission of the GCD calculation algorithm
        /// </summary>
        /// <param name="alghoritm">GCD calculation algorithm</param>
        public GcdAlgorithmMultipleNumbers(IGcdCalculating alghoritm)
        {
            Alghoritm = alghoritm ?? throw new ArgumentNullException(nameof(alghoritm));
        }

        private IGcdCalculating Alghoritm { get; set; }

        /// <summary>
        /// Calculation of the GCD of three integers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>GCD of three integers</returns>
        public int CalculateGcd(int a, int b, int c)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            return Alghoritm.CalculateGcd(gcdOfFirstPair, c);
        }

        /// <summary>
        /// Calculation of the GCD of four numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <param name="d">Fourth number</param>
        /// <returns>GCD of four numbers</returns>
        public int CalculateGcd(int a, int b, int c, int d)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            int gcdOfSecondPair = Alghoritm.CalculateGcd(gcdOfFirstPair, c);
            return Alghoritm.CalculateGcd(gcdOfSecondPair, d);
        }

        /// <summary>
        /// Calculation of GCD of five numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <param name="d">Fourth number</param>
        /// <param name="e">Fifth number</param>
        /// <returns>GCD of five numbers</returns>
        public int CalculateGcd(int a, int b, int c, int d, int e)
        {
            int gcdOfFirstPair = Alghoritm.CalculateGcd(a, b);
            int gcdOfSecondPair = Alghoritm.CalculateGcd(gcdOfFirstPair, c);
            int gcdOfThirdPair = Alghoritm.CalculateGcd(gcdOfSecondPair, d);
            return Alghoritm.CalculateGcd(gcdOfThirdPair, e);
        }
    }
}