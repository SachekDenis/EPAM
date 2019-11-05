using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    [TestClass]
    public class GcdTimeTest
    {
        [TestMethod]
        public void CalculateGcdShouldReturnTimeOfCalculation()
        {
            GcdCalculatingWithTime gcdtime = new GcdCalculatingWithTime(new EuclideanAlgorithm());
            TimeSpan time = new TimeSpan();
            gcdtime.CalculateGcd(248, 364, ref time);
            // Метод должен возвращать время выполнения алгоритма
            Assert.AreNotEqual(new TimeSpan(0), time);
        }
    }
}