using Microsoft.VisualStudio.TestTools.UnitTesting;
using GcdAlgoritm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdTest
{
    /// <summary>
    /// Testing of GCD algoritms
    /// </summary>
    [TestClass]
    public class GcdAlgorithmTest
    {
        /// <summary>
        /// Testing correctness of calculating binary algorithm
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmShouldReturnActualGcd()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(2, binary.CalculateGcd(10, 12));
        }

        /// <summary>
        /// Testing correctness of calculating binary algorithm with zero number
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmWithZeroShouldReturnActualGcd()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(13, binary.CalculateGcd(0, 13));
        }

        /// <summary>
        /// Testing correctness of calculating binary algorithm with one
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmShouldReturnOne()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(1, binary.CalculateGcd(1, 13));
        }

        /// <summary>
        /// Testing correctness of calculating binary negative number
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmWithNegativeArgument()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(6, binary.CalculateGcd(24, -6));
        }

        /// <summary>
        /// Testing correctness of calculating binary with two zero numbers
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmWithZeroesArgument()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(0, binary.CalculateGcd(0, 0));
        }

        /// <summary>
        /// Testing correctness of calculating binary algorithm with two negative numbers
        /// </summary>
        [TestMethod]
        public void CalculateGcdByBinaryAlgorithmWithTwoNegativeArguments()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(6, binary.CalculateGcd(-24, -6));
        }

        /// <summary>
        /// Testing correctness of calculating euclidean algorithm
        /// </summary>
         [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmShouldReturnActualGcd()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(2, euclidean.CalculateGcd(10, 12));
        }

        /// <summary>
        /// Testing correctness of calculating euclidean algorithm with zero
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmWithZeroShouldReturnActualGcd()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(13, euclidean.CalculateGcd(0, 13));
        }


        /// <summary>
        /// Testing correctness of calculating euclidean algorithm with number one
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmShouldReturnOne()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(1, euclidean.CalculateGcd(1, 13));
        }

        /// <summary>
        /// Testing correctness of calculating euclidean algorithm with negative number
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmWithNegativeArgument()
        {
            EuclideanAlgorithm euclidean = new EuclideanAlgorithm();
            Assert.AreEqual(6, euclidean.CalculateGcd(24, -6));
        }

        /// <summary>
        /// Testing correctness of calculating euclidean algorithm with two zeroes
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmWithZeroesArgument()
        {
            EuclideanAlgorithm binary = new EuclideanAlgorithm();
            Assert.AreEqual(0, binary.CalculateGcd(0, 0));
        }

        /// <summary>
        /// Testing correctness of calculating euclidean algorithm with two negative numbers
        /// </summary>
        [TestMethod]
        public void CalculateGcdByEuclideanAlgorithmWithTwoNegativeArguments()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(6, binary.CalculateGcd(-24, -6));
        }
    }
}