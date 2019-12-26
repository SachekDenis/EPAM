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
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 3,1,4,5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 4,2,3,5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 2,1,5,3 })]
        public void TreeDeleteTest(int[] arrayOfValues, int deleteValue, int[] expectedTree)
        {
            Tree<int> tree = new Tree<int>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            tree.Delete(deleteValue);

            var treeArray = tree.ToArray();

            Assert.IsTrue(expectedTree.SequenceEqual(treeArray));
        }

        [TestMethod]
        public void TreeAddNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(()=>tree.Add(null));
        }

        [TestMethod]
        public void TreeDeleteNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(()=>tree.Delete(null));
        }

        [TestMethod]
        public void TreeFindNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(()=>tree.Find(null));
        }

        [TestMethod]
        public void TreeContainsNullMustThrowException()
        {
            Tree<string> tree = new Tree<string>();
            Assert.ThrowsException<ArgumentNullException>(()=>tree.Contains(null));
        }
    }
}
