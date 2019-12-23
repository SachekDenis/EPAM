using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeApp;

namespace TreeTestLibriary
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void TreeAddTest()
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(11);
            tree.Add(1);
            tree.Add(18);
            tree.Add(16);
            tree.Add(23);
            tree.Delete(1);

        }
    }
}
