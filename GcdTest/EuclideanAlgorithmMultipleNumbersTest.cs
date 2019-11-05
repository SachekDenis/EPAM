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
            //НОД(10, 12, 4)=2
            Assert.AreEqual(2, euclidean.CalculateGcd(10, 12, 4));
        }

        [TestMethod]
        public void CalculateGcdFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            //НОД(78, 294, 570, 36)=6
            Assert.AreEqual(6, euclidean.CalculateGcd(78, 294, 570, 36));
        }

        [TestMethod]
        public void CalculateGcdFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            //НОД(450, 390, 120, 24, 66)=6
            Assert.AreEqual(6, euclidean.CalculateGcd(450, 390, 120, 24, 66));
        }
    }
}