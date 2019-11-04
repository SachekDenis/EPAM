using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    [TestClass]
    public class EuclideanAlgorithmTest
    {
        [TestMethod]
        public void CalculateGcdShouldReturnActualGcd()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(euclidean.CalculateGcd(10, 12), 2);
        }

        [TestMethod]
        public void CalculateGcdShouldReturnZero()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(euclidean.CalculateGcd(0, 13), 13);
        }

        [TestMethod]
        public void CalculateGcdShouldReturnOne()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(euclidean.CalculateGcd(1, 13), 1);
        }
    }
}
