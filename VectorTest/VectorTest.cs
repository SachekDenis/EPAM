using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProject;

namespace VectorTest
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void SumOfTwoVectorsMustReturnNewVectorOfSum()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var sumOfVectors = firstVector + secondVector;

            var expectedVector = new Vector(new double[] { 5, 7, 9 });
            Assert.AreEqual(expectedVector, sumOfVectors);
        }

        [TestMethod]
        public void MultiplyingVectorByNumberMustReturnValidResult()
        {
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            int number = 12;
            secondVector = secondVector*number;

            var expectedVector = new Vector(new double[] { 48, 60, 72 });
            Assert.AreEqual(expectedVector, secondVector);
        }
    }
}
