using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdTest
{
    [TestClass]
    public class EuclideanAlgorithmMultipleNumbersTest
    {
        [TestMethod]
        public void CalculateGcdThreeNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(euclidean.CalculateGcd(10, 12, 4), 2);
        }

        [TestMethod]
        public void CalculateGcdFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(euclidean.CalculateGcd(10, 12, 4, 32), 2);
        }

        [TestMethod]
        public void CalculateGcdFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(euclidean.CalculateGcd(10, 12, 4, 32, 44), 2);
        }
    }
}