using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeApp;

namespace TreeTest
{
    /// <summary>
    /// Defines test class TreeTest.
    /// </summary>
    [TestClass]
    public class TreeTest
    {
        /// <summary>
        /// Defines the test method TreeAddTest.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="expectedTree">The expected tree.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 1, 4, 3, 5 })]
        [DataRow(new int[] { 5, 2, 3, 1, 5 }, new int[] { 3, 2, 1, 5, 5 })]
        public void TreeAddTest(int[] arrayOfValues, int[] expectedTree)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var treeArray = tree.ToArray();

            Assert.IsTrue(expectedTree.SequenceEqual(treeArray));
        }

        /// <summary>
        /// Defines the test method TreeDeleteTest.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="deleteValue">The delete value.</param>
        /// <param name="expectedTree">The expected tree.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 3, 1, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 4, 2, 3, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 2, 1, 5, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 1, 4, 3, 5 })]
        public void TreeDeleteTest(int[] arrayOfValues, int deleteValue, int[] expectedTree)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            tree.Delete(deleteValue);

            var treeArray = tree.ToArray();

            Assert.IsTrue(expectedTree.SequenceEqual(treeArray));
        }

        /// <summary>
        /// Defines the test method TreeFindTest.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="findValue">The find value.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4)]
        public void TreeFindTest(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var findedValue = tree.Find(findValue);
            Assert.AreEqual(findValue, findedValue);
        }

        /// <summary>
        /// Defines the test method TreeFindUnexestedValueTestMustReturnDefaultResult.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="findValue">The find value.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 19)]
        public void TreeFindUnexestedValueTestMustReturnDefaultResult(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var findedValue = tree.Find(findValue);
            Assert.AreEqual(0, findedValue);
        }


        /// <summary>
        /// Defines the test method TreeContainsTestMustReturnDefaultTrue.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="findValue">The find value.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4)]
        public void TreeContainsTestMustReturnDefaultTrue(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var isContains = tree.Contains(findValue);
            Assert.IsTrue(isContains);
        }

        /// <summary>
        /// Defines the test method TreeContainsUnexestedValueTestMustReturnDefaultFalse.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="findValue">The find value.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 19)]
        public void TreeContainsUnexestedValueTestMustReturnDefaultFalse(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var isContains = tree.Contains(findValue);
            Assert.IsFalse(isContains);
        }

        /// <summary>
        /// Defines the test method TreeCountTestWithAdd.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [DataRow(new int[] { })]
        public void TreeCountTestWithAdd(int[] arrayOfValues)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var treeArray = tree.ToArray();

            Assert.AreEqual(arrayOfValues.Count(), tree.Count);
        }


        /// <summary>
        /// Defines the test method TreeCountTestWithAddAndDelete.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="deleteValues">The delete values.</param>
        /// <param name="expectedCount">The expected count.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 }, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 7 }, 7)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 0 }, 8)]
        public void TreeCountTestWithAddAndDelete(int[] arrayOfValues, int[] deleteValues, int expectedCount)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            Array.ForEach(deleteValues, element => tree.Delete(element));
            var treeArray = tree.ToArray();

            Assert.AreEqual(expectedCount, tree.Count);
        }

        /// <summary>
        /// Defines the test method TreeAddNullMustThrowException.
        /// </summary>
        [TestMethod]
        public void TreeAddNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Add(null));
        }

        /// <summary>
        /// Defines the test method TreeDeleteNullMustThrowException.
        /// </summary>
        [TestMethod]
        public void TreeDeleteNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Delete(null));
        }

        /// <summary>
        /// Defines the test method TreeFindNullMustThrowException.
        /// </summary>
        [TestMethod]
        public void TreeFindNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Find(null));
        }

        /// <summary>
        /// Defines the test method TreeContainsNullMustThrowException.
        /// </summary>
        [TestMethod]
        public void TreeContainsNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Contains(null));
        }
    }
}
