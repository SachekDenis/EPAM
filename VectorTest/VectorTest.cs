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
            secondVector *= number;

            var expectedVector = new Vector(new double[] { 48, 60, 72 });
            Assert.AreEqual(expectedVector, secondVector);
        }

        [TestMethod]
        public void MultiplayingOfTwoVectorsMustReturnValidResult()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var multiplayingOfTwoVectors = firstVector * secondVector;

            var expectedResult = 32;
            Assert.AreEqual(expectedResult, multiplayingOfTwoVectors);
        }

        [TestMethod]
        public void DifferenceOfTwoVectorsMustReturnValidResult()
        {
            Vector firstVector = new Vector(new double[] { 5, 2, 1 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var differenceOfTwoVectors = firstVector - secondVector;

            var expectedVector = new Vector(new double[] { 1, -3, -5 });
            Assert.AreEqual(expectedVector, differenceOfTwoVectors);
        }

        [TestMethod]
        public void CreatingVectorFromArrayOfWrongSizeMustReturnExeption()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(()=> new Vector(new double[]{1,2,3,4}));
        }

        [TestMethod]
        public void ComparingOfTwoEqualVectorsMustReturnTrue()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 1, 2, 3 });
            Assert.IsTrue(firstVector == secondVector);
        }
    }
}
