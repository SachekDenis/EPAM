using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataIo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTest
{
    /// <summary>
    /// Defines test class DataIoTest.
    /// </summary>
    [TestClass]
    public class DataIoTest
    {
        /// <summary>
        /// Defines the test method TestXmlIoFile.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3,4.5,Color.red,"testXml.xml")]
        public void TestXmlIoFile(double radius, double side,Color color , string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            IDataIo dataIo = new XmlIo();

            dataIo.WriteFile(shapes, fileName);

            Assert.IsTrue(File.Exists(fileName));

            List<IShape> readedShapes = dataIo.ReadFile(fileName);
            File.Delete(fileName);

            Assert.IsTrue(readedShapes.SequenceEqual(shapes));
        }

        /// <summary>
        /// Defines the test method TestStreamIoFile.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3,4.5,Color.red,"testStream.xml")]
        public void TestStreamIoFile(double radius, double side,Color color , string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            IDataIo dataIo = new StreamIo();

            dataIo.WriteFile(shapes, fileName);

            Assert.IsTrue(File.Exists(fileName));

            List<IShape> readedShapes = dataIo.ReadFile(fileName);
            File.Delete(fileName);

            Assert.IsTrue(readedShapes.SequenceEqual(shapes));
        }

        /// <summary>
        /// Defines the test method TestWorkWithFileCrossMethods.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3,4.5,Color.red,"testCross.xml")]
        public void TestWorkWithFileCrossMethods(double radius, double side,Color color , string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            IDataIo dataIoXml = new XmlIo();
            IDataIo dataIoStream = new StreamIo();

            dataIoXml.WriteFile(shapes, fileName);

            Assert.IsTrue(File.Exists(fileName));

            List<IShape> readedShapes = dataIoStream.ReadFile(fileName);
            File.Delete(fileName);

            Assert.IsTrue(readedShapes.SequenceEqual(shapes));
        }
    }
}