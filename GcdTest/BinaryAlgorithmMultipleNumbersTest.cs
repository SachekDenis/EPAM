using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    [TestClass]
    public class BinaryAlgorithmMultipleNumbersTest
    {
        [TestMethod]
        public void CalculateGcdThreeNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(binary.CalculateGcd(10, 12, 4), 2);
        }

        [TestMethod]
        public void CalculateGcdFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(binary.CalculateGcd(10, 12, 4, 32), 2);
        }

        [TestMethod]
        public void CalculateGcdFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(binary.CalculateGcd(10, 12, 4, 32, 44), 2);
        }
    }
}