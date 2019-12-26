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
        public void TreeAddTest()
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(10);
            tree.Delete(1);
            tree.Add(10);
            tree.Add(10);
            tree.Add(9);
            tree.Add(1);
            tree.Add(18);
            tree.Add(16);
            tree.Add(23);
            tree.Delete(1);
            var l = tree.ToList();
            foreach(var node in tree)
            {
                var k = node*3;
            }        

        }
    }
}
