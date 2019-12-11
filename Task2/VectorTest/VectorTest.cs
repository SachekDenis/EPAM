using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProject;

namespace VectorTest
{
    /// <summary>
    /// Tests for Vector class
    /// </summary>
    [TestClass]
    public class VectorTest
    {
        /// <summary>
        /// Testing сorrectness of calculating sum of vectors
        /// </summary>
        [TestMethod]
        public void SumOfTwoVectorsMustReturnNewVectorOfSum()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var expectedVector = new Vector(new double[] { 5, 7, 9 });

            var sumOfVectors = firstVector + secondVector;

            Assert.AreEqual(expectedVector, sumOfVectors);
        }


        /// <summary>
        /// Testing сorrectness of calculating multiplying vector on number
        /// </summary>
        [TestMethod]
        public void MultiplyingVectorByNumberMustReturnValidResult()
        {
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            int number = 12;
            var expectedVector = new Vector(new double[] { 48, 60, 72 });

            secondVector *= number;

            Assert.AreEqual(expectedVector, secondVector);
        }

        /// <summary>
        /// Testing сorrectness of calculating multiplying of vectors
        /// </summary>
        [TestMethod]
        public void MultiplayingOfTwoVectorsMustReturnValidResult()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var expectedResult = 32;

            var multiplayingOfTwoVectors = firstVector * secondVector;

            Assert.AreEqual(expectedResult, multiplayingOfTwoVectors);
        }


        /// <summary>
        /// Testing сorrectness of calculating difference of vectors
        /// </summary>
        [TestMethod]
        public void DifferenceOfTwoVectorsMustReturnValidResult()
        {
            Vector firstVector = new Vector(new double[] { 5, 2, 1 });
            Vector secondVector = new Vector(new double[] { 4, 5, 6 });
            var expectedVector = new Vector(new double[] { 1, -3, -5 });

            var differenceOfTwoVectors = firstVector - secondVector;

            Assert.AreEqual(expectedVector, differenceOfTwoVectors);
        }


        /// <summary>
        /// Testing сorrectness of calculating division of vectors
        /// </summary>
        [TestMethod]
        public void DivisionOfVectorsOnNumverMustReturnValidResult()
        {
            Vector firstVector = new Vector(new double[] { 5, 2, 1 });
            double number = 5;
            var expectedVector = new Vector(new double[] { 1, 2.0 / 5, 1.0 / 5 });

            var division = firstVector / number;

            Assert.AreEqual(expectedVector, division);
        }

        /// <summary>
        /// Testing creating of polinomial from invalid data
        /// </summary>
        [TestMethod]
        public void CreatingVectorFromArrayOfBiggerSizeMustReturnExeption()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => new Vector(new double[] { 1, 2, 3, 4 }));
        }

        /// <summary>
        /// Testing creating of polinomial from invalid data
        /// </summary>
        [TestMethod]
        public void CreatingVectorFromArrayOfSmallerSizeMustReturnExeption()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => new Vector(new double[] { 1, 2 }));
        }

        /// <summary>
        /// Testing creating of polinomial from invalid data
        /// </summary>
        [TestMethod]
        public void CreatingVectorFromNullReturnExeption()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Vector(null));
        }

        /// <summary>
        /// Test equals of vectors
        /// </summary>
        [TestMethod]
        public void ComparingOfTwoEqualVectorsMustReturnTrue()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 1, 2, 3 });

            Assert.IsTrue(firstVector == secondVector);
        }

        /// <summary>
        /// Test equals of vectors
        /// </summary>
        [TestMethod]
        public void ComparingOfTwoInequalVectorsMustReturnFalse()
        {
            Vector firstVector = new Vector(new double[] { 1, 2, 3 });
            Vector secondVector = new Vector(new double[] { 1, 4, 3 });

            Assert.IsFalse(firstVector == secondVector);
        }
    }
}
