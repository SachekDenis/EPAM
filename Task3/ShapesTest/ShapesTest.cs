using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTest
{
    [TestClass]
    public class ShapesTest
    {
        [TestMethod]
        [DataRow(2.1)]
        public void CreatingCircleMustReturnObject(double radius)
        {
            Circle paperCircle = new PaperCircle(radius);
            Circle membraneCircle = new MembraneCircle(radius);
            Assert.IsNotNull(paperCircle);
            Assert.IsNotNull(membraneCircle);
        }


        [TestMethod]
        [DataRow(2.1)]
        public void CreatingSquareMustReturnObject(double side)
        {
            Square paperSquare = new PaperSquare(side);
            Square membraneSquare = new MembraneSquare(side);
            Assert.IsNotNull(paperSquare);
            Assert.IsNotNull(membraneSquare);
        }

        [TestMethod]
        [DataRow(2.1, 3.2)]
        public void CreatingRectangleMustReturnObject(double firstSide, double secondSide)
        {
            Rectangle paperRectangle = new PaperRectangle(firstSide, secondSide);
            Rectangle membraneRectangle = new MembraneRectangle(firstSide, secondSide);
            Assert.IsNotNull(paperRectangle);
            Assert.IsNotNull(membraneRectangle);
        }

        [TestMethod]
        [DataRow(-2.1)]
        [DataRow(0)]
        public void CreatingCircleWithInvalidDataMustThrowsExeption(double radius)
        {
            Assert.ThrowsException<ArgumentException>(() => new PaperCircle(radius));
            Assert.ThrowsException<ArgumentException>(() => new MembraneCircle(radius));
        }

        [TestMethod]
        [DataRow(-2.1)]
        [DataRow(0)]
        public void CreatingSquareWithInvalidDataMustThrowsExeption(double side)
        {
            Assert.ThrowsException<ArgumentException>(() => new PaperSquare(side));
            Assert.ThrowsException<ArgumentException>(() => new MembraneSquare(side));
        }

        [TestMethod]
        [DataRow(-2.1, 2.2)]
        [DataRow(2.1, -2.2)]
        [DataRow(-2.1, -2.2)]
        [DataRow(2.1, 0)]
        [DataRow(-2.1, 0)]
        [DataRow(0, 3.2)]
        [DataRow(0, -3.2)]
        [DataRow(0, 0)]
        public void CreatingRectangleWithInvalidDataMustThrowsExeption(double firstSide, double secondSide)
        {
            Assert.ThrowsException<ArgumentException>(() => new PaperRectangle(firstSide, secondSide));
            Assert.ThrowsException<ArgumentException>(() => new MembraneRectangle(firstSide, secondSide));
        }

        [TestMethod]
        [DataRow(2.1, Math.PI * 2.1 * 2.1)]
        [DataRow(0.1, Math.PI * 0.1 * 0.1)]
        public void TestGetAreaOfCircle(double radius, double expectedArea)
        {
            Circle paperCircle = new PaperCircle(radius);
            Circle membraneCircle = new MembraneCircle(radius);

            Assert.AreEqual(expectedArea, paperCircle.GetArea());
            Assert.AreEqual(expectedArea, membraneCircle.GetArea());
        }

        [TestMethod]
        [DataRow(2.1, 2.1 * 2.1)]
        [DataRow(0.1, 0.1 * 0.1)]
        public void TestGetAreaOfSquare(double side, double expectedArea)
        {
            Square paperSquare = new PaperSquare(side);
            Square membraneSquare = new MembraneSquare(side);

            Assert.AreEqual(expectedArea, paperSquare.GetArea());
            Assert.AreEqual(expectedArea, membraneSquare.GetArea());
        }

        [TestMethod]
        [DataRow(2.1, 0.3, 2.1 * 0.3)]
        [DataRow(0.1, 12, 0.1 * 12)]
        public void TestGetAreaOfRectangle(double firstSide, double secondSide, double expectedArea)
        {
            Rectangle paperRectangle = new PaperRectangle(firstSide, secondSide);
            Rectangle membraneRectangle = new MembraneRectangle(firstSide, secondSide);

            Assert.AreEqual(expectedArea, paperRectangle.GetArea());
            Assert.AreEqual(expectedArea, membraneRectangle.GetArea());
        }

        [TestMethod]
        [DataRow(2.1, Math.PI * 2 * 2.1)]
        [DataRow(0.1, Math.PI * 2 * 0.1)]
        public void TestGetPerimeterOfCircle(double radius, double expectedArea)
        {
            Circle paperCircle = new PaperCircle(radius);
            Circle membraneCircle = new MembraneCircle(radius);

            Assert.AreEqual(expectedArea, paperCircle.GetPerimeter());
            Assert.AreEqual(expectedArea, membraneCircle.GetPerimeter());
        }

        [TestMethod]
        [DataRow(2.1, 2.1 * 4)]
        [DataRow(0.1, 0.1 * 4)]
        public void TestGetPerimeterOfSquare(double side, double expectedArea)
        {
            Square paperSquare = new PaperSquare(side);
            Square membraneSquare = new MembraneSquare(side);

            Assert.AreEqual(expectedArea, paperSquare.GetPerimeter());
            Assert.AreEqual(expectedArea, membraneSquare.GetPerimeter());
        }

        [TestMethod]
        [DataRow(2.1, 0.3, (2.1 + 0.3) * 2)]
        [DataRow(0.1, 12, (0.1 + 12) * 2)]
        public void TestGetPerimeterOfRectangle(double firstSide, double secondSide, double expectedArea)
        {
            Rectangle paperRectangle = new PaperRectangle(firstSide, secondSide);
            Rectangle membraneRectangle = new MembraneRectangle(firstSide, secondSide);

            Assert.AreEqual(expectedArea, paperRectangle.GetPerimeter());
            Assert.AreEqual(expectedArea, membraneRectangle.GetPerimeter());
        }

        [TestMethod]
        [DataRow(2.1, 3.2, 0.4, 3.2, Color.red)]
        [DataRow(2.1, 3.2, 0.4, 3.2, Color.blue)]
        [DataRow(2.1, 3.2, 0.4, 3.2, Color.green)]
        public void TestPaintPaperShapes(double radius, double squareSide, double rectangleFirstSide, double rectangleSecondSide, Color color)
        {
            PaperCircle paperCircle = new PaperCircle(radius);
            PaperRectangle paperRectangle = new PaperRectangle(rectangleFirstSide, rectangleSecondSide);
            PaperSquare paperSquare = new PaperSquare(squareSide);

            paperCircle.Paint(color);
            paperSquare.Paint(color);
            paperRectangle.Paint(color);

            Assert.AreEqual(color, paperCircle.GetColor());
            Assert.AreEqual(color, paperSquare.GetColor());
            Assert.AreEqual(color, paperRectangle.GetColor());
        }

        [TestMethod]
        [DataRow(2.1, 3.2, 0.4, 3.2, Color.none)]
        public void TestPaintNonePaperShapes(double radius, double squareSide, double rectangleFirstSide, double rectangleSecondSide, Color color)
        {
            PaperCircle paperCircle = new PaperCircle(radius);
            PaperRectangle paperRectangle = new PaperRectangle(rectangleFirstSide, rectangleSecondSide);
            PaperSquare paperSquare = new PaperSquare(squareSide);

            Assert.ThrowsException<UnableToPaintException>(() => paperCircle.Paint(color));
            Assert.ThrowsException<UnableToPaintException>(() => paperSquare.Paint(color));
            Assert.ThrowsException<UnableToPaintException>(() => paperRectangle.Paint(color));
        }

        [TestMethod]
        [DataRow(2.1, 3.2, 0.4, 3.2, Color.red)]
        public void TestPaintMoreThenOneTimePaperShapes(double radius, double squareSide, double rectangleFirstSide, double rectangleSecondSide, Color color)
        {
            PaperCircle paperCircle = new PaperCircle(radius);
            PaperRectangle paperRectangle = new PaperRectangle(rectangleFirstSide, rectangleSecondSide);
            PaperSquare paperSquare = new PaperSquare(squareSide);

            paperCircle.Paint(color);
            paperSquare.Paint(color);
            paperRectangle.Paint(color);

            Assert.ThrowsException<UnableToPaintException>(() => paperCircle.Paint(color));
            Assert.ThrowsException<UnableToPaintException>(() => paperSquare.Paint(color));
            Assert.ThrowsException<UnableToPaintException>(() => paperRectangle.Paint(color));
        }
        
        [TestMethod]
        [DataRow(2.3,5.5,4,9,4,3,4,5)]
        public void TestCutShapeFromAnotherShape(double smallerRadius, double biggerRadius, double smallerSide,
                                                 double biggerSide, double smallerFirstSide, double smallerSecondSide,
                                                 double biggerFirstSide, double biggerSecondSide)
        {
            //Cutting shape from another shape is available only in case when area of source shape bigger then area target shape
            //Cutting shape from another shape also is available only for equals materials

            Circle bigCircle = new MembraneCircle(biggerRadius);
            Circle smallCircle = new MembraneCircle(smallerRadius,bigCircle);
            Square bigSquare = new MembraneSquare(biggerSide);
            Square smallSquare = new MembraneSquare(smallerSide,bigSquare);
            Rectangle bigRectangle = new MembraneRectangle(biggerFirstSide,biggerSecondSide);
            Rectangle smallRectangle = new MembraneRectangle(smallerFirstSide,smallerSecondSide,bigRectangle);
            Circle circleFromRectangle = new MembraneCircle(smallerRadius,bigRectangle);
            Square squareFromRectangle = new MembraneSquare(smallerSide,bigRectangle);

            Assert.IsNotNull(smallCircle);
            Assert.IsNotNull(smallSquare);
            Assert.IsNotNull(smallRectangle);
            Assert.IsNotNull(circleFromRectangle);
            Assert.IsNotNull(squareFromRectangle);
        }


        [TestMethod]
        [DataRow(2.3,5.5,Color.red)]
        public void TestCutShapeFromAnotherShapeKeepsColor(double smallerRadius, double biggerRadius, Color color)
        {
            //Cutting shape from another shape is available only in case when area of source shape bigger then area target shape
            //Cutting shape from another shape also is available only for equals materials
            //Color must save for cutted shape

            PaperCircle bigCircle = new PaperCircle(biggerRadius);
            bigCircle.Paint(color);
            PaperCircle smallCircle = new PaperCircle(smallerRadius,bigCircle);


            Assert.IsNotNull(smallCircle);
            Assert.AreEqual(smallCircle.GetColor(),color);
        }

        [TestMethod]
        [DataRow(2.3,5.5)]
        public void TestCutShapeFromAnotherShapeWithAnotherMaterialMustThrowsException(double smallerRadius, double biggerRadius)
        {
            //Cutting shape from another shape is available only for equals materials

            PaperCircle bigCircle = new PaperCircle(biggerRadius);
            Assert.ThrowsException<UnableToCutShapeException>(()=>new MembraneCircle(smallerRadius,bigCircle));

        }

        [TestMethod]
        [DataRow(2.3,5.5)]
        public void TestCutShapeFromAnotherShapeWithSmallerAreaMustThrowsException(double smallerRadius, double biggerRadius)
        {
            //Cutting shape from another shape is available only for equals materials

            PaperCircle bigCircle = new PaperCircle(smallerRadius);
            Assert.ThrowsException<UnableToCutShapeException>(()=>new PaperCircle(biggerRadius,bigCircle));

        }
    }
}
