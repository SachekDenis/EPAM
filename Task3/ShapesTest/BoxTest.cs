﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxProject;
using Shapes;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ShapesTest
{
    /// <summary>
    /// Defines test class BoxTest.
    /// </summary>
    [TestClass]
    public class BoxTest
    {
        /// <summary>
        /// Defines the test method TestAddShapeToBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        [TestMethod]
        [DataRow(4.5)]
        public void TestAddShapeToBox(double radius)
        {
            Box box = new Box();
            Circle circle = new MembraneCircle(radius);
            box.AddShape(circle);

            Assert.AreEqual(circle, box.FindAt(0));
            Assert.AreEqual(circle, box.Find(circle));
        }

        /// <summary>
        /// Defines the test method TestAddTwoSameShapesToBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="expectedCount">The expected count.</param>
        [TestMethod]
        [DataRow(4.5, 1)]
        public void TestAddTwoSameShapesToBox(double radius, int expectedCount)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            Circle secondCircle = new MembraneCircle(radius);

            //Box contains only unique shapes
            box.AddShape(firstCircle);
            box.AddShape(secondCircle);


            Assert.AreEqual(box.Count(), expectedCount);
            Assert.AreEqual(firstCircle, box.FindAt(0));
            Assert.AreEqual(firstCircle, box.Find(firstCircle));
        }

        /// <summary>
        /// Defines the test method TestAddNullToBox.
        /// </summary>
        [TestMethod]
        public void TestAddNullToBox()
        {
            Box box = new Box();

            Assert.ThrowsException<ArgumentNullException>(() => box.AddShape(null));

        }


        /// <summary>
        /// Defines the test method TestFindAtInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, -2)]
        [DataRow(3.2, 3)]
        public void TestFindAtInBox(double radius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => box.FindAt(index));

        }

        /// <summary>
        /// Defines the test method TestFindNullinBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        [TestMethod]
        [DataRow(3.2)]
        public void TestFindNullinBox(double radius)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.ThrowsException<ArgumentNullException>(() => box.Find(null));

        }

        /// <summary>
        /// Defines the test method TestFindElementDontPresentinBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        [TestMethod]
        [DataRow(3.2, 4.2)]
        public void TestFindElementDontPresentinBox(double radius, double newRadius)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.IsNull(box.Find(new PaperCircle(newRadius)));

        }

        /// <summary>
        /// Defines the test method TestReaplaceAtinBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, 0)]
        public void TestReaplaceAtinBox(double radius, double newRadius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            box.AddShape(firstCircle);
            Circle secondCircle = new PaperCircle(newRadius);
            box.ReplaceAt(index, secondCircle);

            Assert.AreEqual(secondCircle, box.FindAt(index));

            Assert.ThrowsException<ArgumentNullException>(()=>box.ReplaceAt(index, null));

        }

        /// <summary>
        /// Defines the test method TestReaplaceAtInvalidDatatinBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, -2)]
        [DataRow(3.2, 4.2, 2)]
        public void TestReaplaceAtInvalidDatatinBox(double radius, double newRadius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            box.AddShape(firstCircle);
            Circle secondCircle = new PaperCircle(newRadius);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => box.ReplaceAt(index, secondCircle));
        }

        /// <summary>
        /// Defines the test method TestPopAtinBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 0)]
        public void TestPopAtinBox(double radius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            box.AddShape(firstCircle);

            Assert.AreEqual(firstCircle, box.FindAt(index));

            IShape popedShape = box.PopAt(index);

            Assert.AreEqual(0, box.Count());
            Assert.AreEqual(popedShape, firstCircle);

        }

        /// <summary>
        /// Defines the test method TestPopAtInvalidDatainBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 2)]
        public void TestPopAtInvalidDatainBox(double radius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            box.AddShape(firstCircle);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => box.PopAt(index));

        }

        /// <summary>
        /// Defines the test method TestFindTotalAreaInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, -2)]
        [DataRow(3.2, 4.2, 2)]
        public void TestFindTotalAreaInBox(double radius, double newRadius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            Circle secondCircle = new PaperCircle(newRadius);

            Assert.AreEqual(0,box.GetTotalArea());
            box.AddShape(firstCircle);
            box.AddShape(secondCircle);
            Assert.AreEqual(firstCircle.GetArea()+secondCircle.GetArea(),box.GetTotalArea());
        }

        /// <summary>
        /// Defines the test method TestFindTotalPerimeterInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="index">The index.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, -2)]
        [DataRow(3.2, 4.2, 2)]
        public void TestFindTotalPerimeterInBox(double radius, double newRadius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            Circle secondCircle = new PaperCircle(newRadius);

            Assert.AreEqual(0,box.GetTotalPerimeter());
            box.AddShape(firstCircle);
            box.AddShape(secondCircle);
            Assert.AreEqual(firstCircle.GetPerimeter()+secondCircle.GetPerimeter(),box.GetTotalPerimeter());
        }

        /// <summary>
        /// Defines the test method TestGetAllCirclesFromBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="numberOfCircles">The number of circles.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, 2, 2)]
        public void TestGetAllCirclesFromBox(double radius, double newRadius, double side, int numberOfCircles)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            Circle secondCircle = new PaperCircle(newRadius);
            Square square = new PaperSquare(side);

            Assert.AreEqual(0,box.GetAllCircles().Count);

            box.AddShape(firstCircle);
            box.AddShape(secondCircle);
            box.AddShape(square);

            Assert.IsTrue(new List<Circle>(){ firstCircle, secondCircle }.SequenceEqual(box.GetAllCircles()));
            Assert.AreEqual(numberOfCircles, box.GetAllCircles().Count);
        }

        /// <summary>
        /// Defines the test method TestGetAllMembraneFromBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="newRadius">The new radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="numberOfMembrane">The number of membrane.</param>
        [TestMethod]
        [DataRow(3.2, 4.2, 2, 2)]
        public void TestGetAllMembraneFromBox(double radius, double newRadius, double side, int numberOfMembrane)
        {
            Box box = new Box();
            MembraneCircle firstCircle = new MembraneCircle(radius);
            PaperCircle secondCircle = new PaperCircle(newRadius);
            MembraneSquare square = new MembraneSquare(side);

            Assert.AreEqual(0,box.GetAllMembrane().Count);

            box.AddShape(firstCircle);
            box.AddShape(secondCircle);
            box.AddShape(square);

            Assert.IsTrue(new List<IMembrane>(){ firstCircle, square }.SequenceEqual(box.GetAllMembrane()));
            Assert.AreEqual(numberOfMembrane, box.GetAllCircles().Count);
        }

        /// <summary>
        /// Defines the test method TestStreamIoInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestStreamIoInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SaveAllShapesStreamWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesStreamReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Count,box.Count());

            Assert.IsTrue(shapes.SequenceEqual(new List<IShape>() { box.FindAt(0), box.FindAt(1) }));
        }

        /// <summary>
        /// Defines the test method TestXmlIoInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestXmlIoInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SaveAllShapesXmlWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesXmlReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Count, box.Count());

            Assert.IsTrue(shapes.SequenceEqual(box.GetAllShapes()));
        }

        /// <summary>
        /// Defines the test method TestXmlWritetOnlyPaperInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestXmlWritetOnlyPaperInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SavePaperShapesXmlWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesXmlReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Where(e => e is IPaper).Count(), box.Count());

            Assert.IsTrue(shapes.Where(e=>e is IPaper).SequenceEqual(box.GetAllShapes()));
        }


        /// <summary>
        /// Defines the test method TestXmlWritetOnlyMembraneInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestXmlWritetOnlyMembraneInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SaveMembraneShapesXmlWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesXmlReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Where(e => e is IMembrane).Count(), box.Count());

            Assert.IsTrue(shapes.Where(e => e is IMembrane).SequenceEqual(box.GetAllShapes()));
        }

        /// <summary>
        /// Defines the test method TestStreamWritetOnlyPaperInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestStreamWritetOnlyPaperInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SavePaperShapesStreamWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesXmlReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Where(e => e is IPaper).Count(), box.Count());

            Assert.IsTrue(shapes.Where(e => e is IPaper).SequenceEqual(box.GetAllShapes()));
        }


        /// <summary>
        /// Defines the test method TestStreamWritetOnlyMembraneInBox.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="side">The side.</param>
        /// <param name="color">The color.</param>
        /// <param name="fileName">Name of the file.</param>
        [TestMethod]
        [DataRow(2.3, 4.5, Color.red, "testXml.xml")]
        public void TestStreamWritetOnlyMembraneInBox(double radius, double side, Color color, string fileName)
        {
            List<IShape> shapes = new List<IShape> { new PaperCircle(radius), new MembraneSquare(side) };
            (shapes[0] as IPaper).Paint(color);
            Box box = new Box();

            shapes.ForEach(e => box.AddShape(e));

            box.SaveMembraneShapesStreamWriter(fileName);

            Assert.IsTrue(File.Exists(fileName));

            box.ReadShapesXmlReader(fileName);

            File.Delete(fileName);

            Assert.AreEqual(shapes.Where(e => e is IMembrane).Count(), box.Count());

            Assert.IsTrue(shapes.Where(e => e is IMembrane).SequenceEqual(box.GetAllShapes()));
        }
    }
}
