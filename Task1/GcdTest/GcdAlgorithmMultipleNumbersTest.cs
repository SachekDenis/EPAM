using System;
using GcdAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GcdTest
{
    /// <summary>
    /// Class of tests for calculating the GCD of several numbers
    /// </summary>
    [TestClass]
    public class GcdAlgorithmMultipleNumbersTest
    {
        /// <summary>
        /// Testing the calculation GCD of 3 numbers by binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmThreeNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(2, binary.CalculateGcd(10, 12, 4));
        }

        /// <summary>
        /// Testing the calculation GCD of 4 numbers by binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(6, binary.CalculateGcd(78, 294, 570, 36));
        }

        /// <summary>
        /// Testing the calculation GCD of 5 numbers by binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers binary = new GcdAlgorithmMultipleNumbers(new BinaryAlgorithm());
            Assert.AreEqual(6, binary.CalculateGcd(450, 390, 120, 24, 66));
        }

        /// <summary>
        /// Testing the calculation GCD of 3 numbers by euclidean algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmThreeNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(2, euclidean.CalculateGcd(10, 12, 4));
        }


        /// <summary>
        /// Testing the calculation GCD of 4 numbers by euclidean algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmFourNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(6, euclidean.CalculateGcd(78, 294, 570, 36));
        }

        /// <summary>
        /// Testing the calculation GCD of 5 numbers by euclidean algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmFiveNumbersShouldReturnActualGcd()
        {
            GcdAlgorithmMultipleNumbers euclidean = new GcdAlgorithmMultipleNumbers(new EuclideanAlgorithm());
            Assert.AreEqual(6, euclidean.CalculateGcd(450, 390, 120, 24, 66));
        }

        /// <summary>
        /// Testing invalid argument in constructor
        /// </summary>
        [TestMethod]
        public void CalculateGcdWithNullArgumentShouldThrowExeption()
        {
            Assert.ThrowsException<ArgumentNullException>(()=>new GcdAlgorithmMultipleNumbers(null));
        }
    }
}