using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    /// <summary>
    /// Testing of preparing data for histogram and calculating time
    /// </summary>
    [TestClass]
    public class HistogramDataTest
    {

        /// <summary>
        /// Histogram data must contains time of calculation
        /// </summary>
        [TestMethod]
        public void HistogramCalculationTimeShouldReturnTimes()
        {
            HistogramData histogramData = new HistogramData();
            TimeSpan euclideanTime = new TimeSpan();
            TimeSpan binaryTime = new TimeSpan();
            histogramData.GetGcdCalculationTime(248, 364, ref euclideanTime, ref binaryTime);

            // The method should return the execution time of the algorithms
            Assert.AreNotEqual(new TimeSpan(0), euclideanTime);
            Assert.AreNotEqual(new TimeSpan(0), binaryTime);
        }

                /// <summary>
        /// Testing execution time of the euclidian algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdEuclidianShouldReturnTimeOfCalculation()
        {
            HistogramData gcdtime = new HistogramData();
            TimeSpan time = new TimeSpan();
            gcdtime.CalculateGcd(248, 364, ref time, new EuclideanAlgorithm());
            // The method should return the execution time of the algorithm
            Assert.AreNotEqual(new TimeSpan(0), time);
        }


        /// <summary>
        /// Testing execution time of the binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdBinaryShouldReturnTimeOfCalculation()
        {
            HistogramData gcdtime = new HistogramData();
            TimeSpan time = new TimeSpan();
            gcdtime.CalculateGcd(248, 364, ref time, new BinaryAlgorithm());
            // The method should return the execution time of the algorithm
            Assert.AreNotEqual(new TimeSpan(0), time);
        }


        /// <summary>
        /// Testing null argument
        /// </summary>
        [TestMethod]
        public void CalculateGcdNullShouldThrowExeption()
        {
            TimeSpan time = new TimeSpan();
            Assert.ThrowsException<ArgumentNullException>(()=>new HistogramData().CalculateGcd(1,2,ref time,null));
        }
    }
}