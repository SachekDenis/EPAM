using Microsoft.VisualStudio.TestTools.UnitTesting;
using GcdAlgoritm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdTest
{
    [TestClass]
    public class BinaryAlgorithmTest
    {
        [TestMethod]
        public void CalculateGcdShouldReturnActualGcd()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(2, binary.CalculateGcd(10, 12));
        }

        [TestMethod]
        public void CalculateGcdWithZeroShouldReturnActualGcd()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(13, binary.CalculateGcd(0, 13));
        }

        [TestMethod]
        public void CalculateGcdShouldReturnOne()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(1, binary.CalculateGcd(1, 13));
        }

        [TestMethod]
        public void CalculateGcdWithNegativeArgument()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(6, binary.CalculateGcd(24, -6));
        }

        [TestMethod]
        public void CalculateGcdWithZeroesArgument()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(0, binary.CalculateGcd(0, 0));
        }
    }
}