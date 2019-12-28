using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Serialization;
using TreeApp;

namespace TreeTest
{
    /// <summary>
    /// Defines test class TreeWithStudentsTest.
    /// </summary>
    [TestClass]
    public class TreeWithStudentsTest
    {
        /// <summary>
        /// Defines the test method StoringTestsInTreeTest.
        /// </summary>
        /// <param name="marks">The marks.</param>
        /// <param name="names">The names.</param>
        /// <param name="tests">The tests.</param>
        [TestMethod]
        [DataRow(new int[] { 7, 4, 9, 2, 1 },
                 new string[] { "Denis", "Max", "Vadim", "Vlad", "Pavel" },
                 new string[] { "English", "Math", "Art", "English", "Math" })]
        public void StoringTestsInTreeTest(int[] marks, string[] names, string[] tests)
        {
            List<TestData> inputList = new List<TestData>() {
            new TestData() { Name = names[0], TestMark = marks[0], TestName = tests[0], TestTime = DateTime.Now },
            new TestData() { Name = names[1], TestMark = marks[1], TestName = tests[1], TestTime = DateTime.Now },
            new TestData() { Name = names[2], TestMark = marks[2], TestName = tests[2], TestTime = DateTime.Now },
            new TestData() { Name = names[3], TestMark = marks[3], TestName = tests[3], TestTime = DateTime.Now },
            new TestData() { Name = names[4], TestMark = marks[4], TestName = tests[4], TestTime = DateTime.Now }};
            List<TestData> expectedList = new List<TestData>() { inputList[0], inputList[3], inputList[4], inputList[1], inputList[2] };

            Tree<TestData> testsTree = new Tree<TestData>();

            inputList.ForEach(element => testsTree.Add(element));

            List<TestData> treeToList = testsTree.ToList();

            Assert.IsTrue(expectedList.SequenceEqual(treeToList));
        }

        /// <summary>
        /// Defines the test method SerializeTestDataTreeTest.
        /// </summary>
        /// <param name="marks">The marks.</param>
        /// <param name="names">The names.</param>
        /// <param name="tests">The tests.</param>
        /// <param name="path">The path.</param>
        [TestMethod]
        [DataRow(new int[] { 7, 4, 9, 2, 1 },
                 new string[] { "Denis", "Max", "Vadim", "Vlad", "Pavel" },
                 new string[] { "English", "Math", "Art", "English", "Math" },
                 "1.xml")]
        public void SerializeTestDataTreeTest(int[] marks, string[] names, string[] tests, string path)
        {
            List<TestData> inputList = new List<TestData>() {
            new TestData() { Name = names[0], TestMark = marks[0], TestName = tests[0], TestTime = DateTime.Now },
            new TestData() { Name = names[1], TestMark = marks[1], TestName = tests[1], TestTime = DateTime.Now },
            new TestData() { Name = names[2], TestMark = marks[2], TestName = tests[2], TestTime = DateTime.Now },
            new TestData() { Name = names[3], TestMark = marks[3], TestName = tests[3], TestTime = DateTime.Now },
            new TestData() { Name = names[4], TestMark = marks[4], TestName = tests[4], TestTime = DateTime.Now }};

            Tree<TestData> testsTree = new Tree<TestData>();

            Serializer<Tree<TestData>> serializer = new Serializer<Tree<TestData>>();

            inputList.ForEach(element => testsTree.Add(element));

            serializer.Serialize(testsTree, path);

            Assert.IsTrue(File.Exists(path));
            Tree<TestData> treeFromXml = serializer.Deserialize(path);

            Assert.AreEqual(testsTree, treeFromXml);
            File.Delete(path);
        }
    }
}
