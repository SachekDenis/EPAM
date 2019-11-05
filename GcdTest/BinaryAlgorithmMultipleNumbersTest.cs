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
            //НОД(10, 12, 4)=2
            Assert.AreEqual(2, binary.CalculateGcd(10, 12, 4));
        }

        [TestMethod]
        public void CalculateGcdFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            //НОД(78, 294, 570, 36)=6
            Assert.AreEqual(6, binary.CalculateGcd(78, 294, 570, 36));
        }

        [TestMethod]
        public void CalculateGcdFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            //НОД(450, 390, 120, 24, 66)=6
            Assert.AreEqual(6, binary.CalculateGcd(450, 390, 120, 24, 66));
        }
    }
}