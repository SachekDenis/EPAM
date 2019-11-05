using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    [TestClass]
    public class HistogramDataTest
    {
        [TestMethod]
        public void HistogramCalculationTimeShouldReturnTimes()
        {
            HistogramData histogramData = new HistogramData();
            TimeSpan euclideanTime = new TimeSpan();
            TimeSpan binaryTime = new TimeSpan();
            histogramData.GetGcdCalculationTime(248, 364, ref euclideanTime, ref binaryTime);

            // Метод должен возвращать время выполнения алгоритмов
            Assert.AreNotEqual(new TimeSpan(0), euclideanTime);
            Assert.AreNotEqual(new TimeSpan(0), binaryTime);
        }
    }
}