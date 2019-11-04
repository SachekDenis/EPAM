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
            Assert.AreEqual(binary.CalculateGcd(10, 12), 2);
        }

        [TestMethod]
        public void CalculateGcdShouldReturnZero()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(binary.CalculateGcd(0, 13), 13);
        }

        [TestMethod]
        public void CalculateGcdShouldReturnOne()
        {
            BinaryAlgorithm binary = new BinaryAlgorithm();
            Assert.AreEqual(binary.CalculateGcd(1, 13), 1);
        }
    }
}