using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeApp;

namespace TreeTestLibriary
{
    [TestClass]
    public class TreeTest
    {
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

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 19)]
        public void TreeFindUnexestedValueTestMustReturnDefaultResult(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var findedValue = tree.Find(findValue);
            Assert.AreEqual(0, findedValue);
        }


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

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 19)]
        public void TreeContainsUnexestedValueTestMustReturnDefaultFalse(int[] arrayOfValues, int findValue)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            var isContains = tree.Contains(findValue);
            Assert.IsFalse(isContains);
        }

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

        [TestMethod]
        public void TreeAddNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Add(null));
        }

        [TestMethod]
        public void TreeDeleteNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Delete(null));
        }

        [TestMethod]
        public void TreeFindNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Find(null));
        }

        [TestMethod]
        public void TreeContainsNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.Contains(null));
        }
    }
}
