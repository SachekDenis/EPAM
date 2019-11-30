using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polinmial;

namespace PolinomialTest
{
    /// <summary>
    /// Tests of polinomial class
    /// </summary>
    [TestClass]
    public class PolinomialTest
    {
        /// <summary>
        /// Testing creating of polinomial from valid data
        /// </summary>
        [TestMethod]
        public void CreatingPolinomial()
        {
            Polinomial polinomial = new Polinomial(new double[] {1,2,3});
            int expectedDegree = 2;
            Assert.AreEqual(expectedDegree, polinomial.Degree);
        }

        /// <summary>
        /// Testing creating of polinomial from empty array
        /// </summary>
        [TestMethod]
        public void CreatingPolinomialFromEmptyArrayMustThrowExeption()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Polinomial(new double[] { }));
        }


        /// <summary>
        /// Testing сorrectness of calculating sum of polinomials
        /// </summary>
        [TestMethod]
        public void SumOfTwoPolinomialsNustReturnExpectedResult()
        {
            Polinomial firstPolimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolimomial = new Polinomial(new double[] { 11, 6, -12 });

            Polinomial sumOfPolinomials = firstPolimomial + secondPolimomial;

            Polinomial expectedSumOfPolinomials = new Polinomial(new double[] { 16, 3, -12, 9 });

            Assert.AreEqual(expectedSumOfPolinomials, sumOfPolinomials);
        }


        /// <summary>
        /// Testing сorrectness of calculating difference of polinomials
        /// </summary>
        [TestMethod]
        public void DifferenceOfTwoPolinomialsNustReturnExpectedResult()
        {
            Polinomial firstPolimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolimomial = new Polinomial(new double[] { 11, 6, -12 });

            Polinomial sumOfPolinomials = firstPolimomial - secondPolimomial;

            Polinomial expectedSumOfPolinomials = new Polinomial(new double[] { -6, -9, 12, 9 });

            Assert.AreEqual(expectedSumOfPolinomials, sumOfPolinomials);
        }

        /// <summary>
        /// Testing сorrectness of calculating multiplying on number
        /// </summary>
        [TestMethod]
        public void MultiplyingPolinomialsByNumberMustReturnValidResult()
        {
            Polinomial polimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            int number = 9;
            polimomial *= number;

            var expectedPolimomial = new Polinomial(new double[] { 45, -27, 0, 81 });
            Assert.AreEqual(expectedPolimomial, polimomial);
        }


        /// <summary>
        /// Testing сorrectness of calculating multiplying on zero
        /// </summary>
        [TestMethod]
        public void MultiplyingPolinomialsByZeroNumberMustReturnValidResult()
        {
            Polinomial polimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            int number = 0;
            polimomial *= number;

            var expectedPolimomial = new Polinomial(new double[] { 0, 0, 0, 0 });
            Assert.AreEqual(expectedPolimomial, polimomial);
        }

        /// <summary>
        /// Testing сorrectness of calculating multiplying on negative number
        /// </summary>
        [TestMethod]
        public void MultiplyingPolinomialsByZNegativeNumberMustReturnValidResult()
        {
            Polinomial polimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            int number = -3;
            polimomial *= number;

            var expectedPolimomial = new Polinomial(new double[] { -15, 9, 0, -27 });
            Assert.AreEqual(expectedPolimomial, polimomial);
        }


        /// <summary>
        /// Testing сorrectness of calculating multiplying of polinomilas with different size
        /// </summary>
        [TestMethod]
        public void MultiplayingOfTwoPolinomialsDifferentSizeMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 11, 6, -12 });
            var multiplayingOfTwoPolinomials = firstPolinomial * secondPolinomial;

            var expectedPolinomial = new Polinomial(new double[] { 55, -3, -78, 135, 54, -108 });

            Assert.AreEqual(expectedPolinomial, multiplayingOfTwoPolinomials);
        }


        /// <summary>
        /// Testing сorrectness of calculating multiplying of polinomilas with same size
        /// </summary>
        [TestMethod]
        public void MultiplayingOfTwoPolinomialsSameSizeMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 11, 6, -12, 3 });
            var multiplayingOfTwoPolinomials = firstPolinomial * secondPolinomial;

            var expectedPolinomial = new Polinomial(new double[] { 55, -3, -78, 150, 45, -108, 27 });

            Assert.AreEqual(expectedPolinomial, multiplayingOfTwoPolinomials);
        }


        /// <summary>
        /// Testing сorrectness of calculating dividing of polinomilas
        /// </summary>
        [TestMethod]
        public void DividingOfTwoPolinomialsMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] {-1, 0, -7, 0, 10 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 3, -1, 1 });
            Polinomial dividingOfTwoPolinomials = firstPolinomial / secondPolinomial;

            Polinomial expectedPolinomial = new Polinomial(new double[] { -27,10,10 });

            Assert.AreEqual(expectedPolinomial, dividingOfTwoPolinomials);
        }


        /// <summary>
        /// Testing сorrectness of calculating dividing of polinomial on zero polimial
        /// </summary>
        [TestMethod]
        public void DividingPolinomialOnZeroPolinomialMustReturnNull()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] {-1, 0, -7, 0, 10 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 0 });
            Polinomial dividingOfTwoPolinomials = firstPolinomial / secondPolinomial;

            Polinomial expectedPolinomial = null;

            Assert.AreEqual(expectedPolinomial, dividingOfTwoPolinomials);
        }


        /// <summary>
        /// Testing сorrectness of calculating dividing of polinomial on smaller polinomial
        /// </summary>
        [TestMethod]
        public void DividingPolinomialWithSmallerDegreeOnPolinomialWithBiggerDegreeMustReturnNull()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] { 3, -1, 1 });
            Polinomial secondPolinomial = new Polinomial(new double[] {-1, 0, -7, 0, 10 });
            Polinomial dividingOfTwoPolinomials = firstPolinomial / secondPolinomial;

            Polinomial expectedPolinomial = null;

            Assert.AreEqual(expectedPolinomial, dividingOfTwoPolinomials);
        }
    }
}
