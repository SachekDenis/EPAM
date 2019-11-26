using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    /// <summary>
    /// Testing execution time of the algorithms
    /// </summary>
    [TestClass]
    public class GcdTimeTest
    {

        /// <summary>
        /// Testing execution time of the euclidian algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdEuclidianShouldReturnTimeOfCalculation()
        {
            GcdCalculatingWithTime gcdtime = new GcdCalculatingWithTime(new EuclideanAlgorithm());
            TimeSpan time = new TimeSpan();
            gcdtime.CalculateGcd(248, 364, ref time);
            // The method should return the execution time of the algorithm
            Assert.AreNotEqual(new TimeSpan(0), time);
        }


        /// <summary>
        /// Testing execution time of the binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdBinaryShouldReturnTimeOfCalculation()
        {
            GcdCalculatingWithTime gcdtime = new GcdCalculatingWithTime(new BinaryAlgorithm());
            TimeSpan time = new TimeSpan();
            gcdtime.CalculateGcd(248, 364, ref time);
            // The method should return the execution time of the algorithm
            Assert.AreNotEqual(new TimeSpan(0), time);
        }


        /// <summary>
        /// Testing null argument
        /// </summary>
        [TestMethod]
        public void CalculateGcdNullShouldThrowExeption()
        {
            Assert.ThrowsException<ArgumentNullException>(()=>new GcdCalculatingWithTime(null));
        }
    }
}