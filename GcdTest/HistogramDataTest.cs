using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    /// <summary>
    /// Testing of preparing data for histogram
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
    }
}