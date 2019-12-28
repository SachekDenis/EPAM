using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using TreeApp;

namespace TreeTest
{
    /// <summary>
    /// Defines test class TreeSerializeTest.
    /// </summary>
    [TestClass]
    public class TreeSerializeTest
    {
        /// <summary>
        /// Defines the test method TreeSerializationTest.
        /// </summary>
        /// <param name="arrayOfValues">The array of values.</param>
        /// <param name="path">The path.</param>
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, "1.xml")]
        public void TreeSerializationTest(int[] arrayOfValues, string path)
        {
            Tree<int> tree = new Tree<int>();
            Serializer<Tree<int>> serializer = new Serializer<Tree<int>>();
            Array.ForEach(arrayOfValues, element => tree.Add(element));
            serializer.Serialize(tree, path);
            Assert.IsTrue(File.Exists(path));
            Tree<int> treeFromXml = serializer.Deserialize(path);
            Assert.AreEqual(tree, treeFromXml);
            File.Delete(path);
        }
    }
}
