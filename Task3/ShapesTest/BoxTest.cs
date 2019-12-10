using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxProject;
using Shapes;

namespace ShapesTest
{
    [TestClass]
    public class BoxTest
    {
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

        [TestMethod]
        public void TestAddNullToBox()
        {
            Box box = new Box();

            Assert.ThrowsException<ArgumentNullException>(() => box.AddShape(null));

        }


        [TestMethod]
        [DataRow(3.2, -2)]
        [DataRow(3.2, 3)]
        public void TestFindAtInBox(double radius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => box.FindAt(index));

        }

        [TestMethod]
        [DataRow(3.2)]
        public void TestFindNullinBox(double radius)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.ThrowsException<ArgumentNullException>(() => box.Find(null));

        }

        [TestMethod]
        [DataRow(3.2, 4.2)]
        public void TestFindElementDontPresentinBox(double radius, double newRadius)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);

            Assert.IsNull(box.Find(new PaperCircle(newRadius)));

        }

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

        [TestMethod]
        [DataRow(3.2, 2)]
        public void TestPopAtInvalidDatainBox(double radius, int index)
        {
            Box box = new Box();
            Circle firstCircle = new MembraneCircle(radius);
            box.AddShape(firstCircle);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => box.PopAt(index));

        }

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
    }
}
