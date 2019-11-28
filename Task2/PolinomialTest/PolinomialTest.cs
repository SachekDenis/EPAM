using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polinmial;

namespace PolinomialTest
{
    [TestClass]
    public class PolinomialTest
    {
        [TestMethod]
        public void CreatingPolinomial()
        {
            Polinomial polinomial = new Polinomial(new double[] {1,2,3});
            int expectedDegree = 2;
            Assert.AreEqual(expectedDegree, polinomial.Degree);
        }

        [TestMethod]
        public void CreatingPolinomialFromEmptyArrayMustThrowExeption()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Polinomial(new double[] { }));
        }

        [TestMethod]
        public void SumOfTwoPolinomialsNustReturnExpectedResult()
        {
            Polinomial firstPolimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolimomial = new Polinomial(new double[] { 11, 6, -12 });

            Polinomial sumOfPolinomials = firstPolimomial + secondPolimomial;

            Polinomial expectedSumOfPolinomials = new Polinomial(new double[] { 16, 3, -12, 9 });

            Assert.AreEqual(expectedSumOfPolinomials, sumOfPolinomials);
        }

        [TestMethod]
        public void DifferenceOfTwoPolinomialsNustReturnExpectedResult()
        {
            Polinomial firstPolimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolimomial = new Polinomial(new double[] { 11, 6, -12 });

            Polinomial sumOfPolinomials = firstPolimomial - secondPolimomial;

            Polinomial expectedSumOfPolinomials = new Polinomial(new double[] { -6, -9, 12, 9 });

            Assert.AreEqual(expectedSumOfPolinomials, sumOfPolinomials);
        }

        [TestMethod]
        public void MultiplyingPolinomialsByNumberMustReturnValidResult()
        {
            Polinomial polimomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            int number = 9;
            polimomial *= number;

            var expectedPolimomial = new Polinomial(new double[] { 45, -27, 0, 81 });
            Assert.AreEqual(expectedPolimomial, polimomial);
        }

        [TestMethod]
        public void MultiplayingOfTwoPolinomialsMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] { 5, -3, 0, 9 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 11, 6, -12 });
            var multiplayingOfTwoPolinomials = firstPolinomial * secondPolinomial;

            var expectedPolinomial = new Polinomial(new double[] { 55, -3, -78, 135, 54, -108 });

            Assert.AreEqual(expectedPolinomial, multiplayingOfTwoPolinomials);
        }

        [TestMethod]
        public void DividingOfTwoPolinomialsMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] {-1, 0, -7, 0, 10 });
            Polinomial secondPolinomial = new Polinomial(new double[] { 3, -1, 1 });
            Polinomial dividingOfTwoPolinomials = firstPolinomial / secondPolinomial;

            Polinomial expectedPolinomial = new Polinomial(new double[] { -27,10,10 });

            Assert.AreEqual(expectedPolinomial, dividingOfTwoPolinomials);
        }

        [TestMethod]
        public void DividingPolinomialWithSmallerDegreeOnPolinomialWithBiggerDegreeMustReturnValidResult()
        {
            Polinomial firstPolinomial = new Polinomial(new double[] { 3, -1, 1 });
            Polinomial secondPolinomial = new Polinomial(new double[] {-1, 0, -7, 0, 10 });
            Polinomial dividingOfTwoPolinomials = firstPolinomial / secondPolinomial;

            Polinomial expectedPolinomial = null;

            Assert.AreEqual(expectedPolinomial, dividingOfTwoPolinomials);
        }
    }
}
