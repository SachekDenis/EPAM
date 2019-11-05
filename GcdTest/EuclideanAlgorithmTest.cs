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
            Assert.AreEqual(2, euclidean.CalculateGcd(10, 12));
        }

        [TestMethod]
        public void CalculateGcdWithZeroShouldReturnActualGcd()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(13, euclidean.CalculateGcd(0, 13));
        }

        [TestMethod]
        public void CalculateGcdShouldReturnOne()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(1, euclidean.CalculateGcd(1, 13));
        }

        [TestMethod]
        public void CalculateGcdWithNegativeArgument()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(6, euclidean.CalculateGcd(24, -6));
        }

        [TestMethod]
        public void CalculateGcdWithZeroesArgument()
        {
            EuclideanAlgorithm binary = new EuclideanAlgorithm();
            Assert.AreEqual(0, binary.CalculateGcd(0, 0));
        }
    }
}