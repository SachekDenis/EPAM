using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTest
{
    /// <summary>
    /// Defines test class ShapesTest.
    /// </summary>
    [TestClass]
    public class ShapesTest
    {
        /// <summary>
        /// Defines the test method CreatingCircleMustReturnObject.
        /// </summary>
        /// <param name="radius">The radius.</param>
        [TestMethod]
        [DataRow(2.1)]
        public void CreatingCircleMustReturnObject(double radius)
        {
            Circle paperCircle = new PaperCircle(radius);
            Circle membraneCircle = new MembraneCircle(radius);
            Assert.IsNotNull(paperCircle);
            Assert.IsNotNull(membraneCircle);
        }


        /// <summary>
        /// Defines the test method CreatingSquareMustReturnObject.
        /// </summary>
        /// <param name="side">The side.</param>
        [TestMethod]
        [DataRow(2.1)]
        public void CreatingSquareMustReturnObject(double side)
        {
            Square paperSquare = new PaperSquare(side);
            Square membraneSquare = new MembraneSquare(side);
            Assert.IsNotNull(paperSquare);
            Assert.IsNotNull(membraneSquare);
        }

        /// <summary>
        /// Defines the test method CreatingRectangleMustReturnObject.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        [TestMethod]
        [DataRow(2.1, 3.2)]
        public void CreatingRectangleMustReturnObject(double firstSide, double secondSide)
        {
            Rectangle paperRectangle = new PaperRectangle(firstSide, secondSide);
            Rectangle membraneRectangle = new MembraneRectangle(firstSide, secondSide);
            Assert.IsNotNull(paperRectangle);
            Assert.IsNotNull(membraneRectangle);
        }

        /// <summary>
        /// Defines the test method CreatingCircleWithInvalidDataMustThrowsExeption.
        /// </summary>
        /// <param name="radius">The radius.</param>
        [TestMethod]
        [DataRow(-2.1)]
        [DataRow(0)]
        public void CreatingCircleWithInvalidDataMustThrowsExeption(double radius)
        {
            Assert.ThrowsException<ArgumentException>(() => new PaperCircle(radius));
            Assert.ThrowsException<ArgumentException>(() => new MembraneCircle(radius));
        }

        /// <summary>
        /// Defines the test method CreatingSquareWithInvalidDataMustThrowsExeption.
        /// </summary>
        /// <param name="side">The side.</param>
        [TestMethod]
        [DataRow(-2.1)]
        [DataRow(0)]
        public void CreatingSquareWithInvalidDataMustThrowsExeption(double side)
        {
            Assert.ThrowsException<ArgumentException>(() => new PaperSquare(side));
            Assert.ThrowsException<ArgumentException>(() => new MembraneSquare(side));
        }

        /// <summary>
        /// Defines the test method CreatingRectangleWithInvalidDataMustThrowsExeption.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
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

        /// <summary>
        /// Defines the test method TestGetAreaOfCircle.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestGetAreaOfSquare.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestGetAreaOfRectangle.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestGetPerimeterOfCircle.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestGetPerimeterOfSquare.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestGetPerimeterOfRectangle.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="expectedArea">The expected area.</param>
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

        /// <summary>
        /// Defines the test method TestPaintPaperShapes.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="squareSide">The square side.</param>
        /// <param name="rectangleFirstSide">The rectangle first side.</param>
        /// <param name="rectangleSecondSide">The rectangle second side.</param>
        /// <param name="color">The color.</param>
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

        /// <summary>
        /// Defines the test method TestPaintNonePaperShapes.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="squareSide">The square side.</param>
        /// <param name="rectangleFirstSide">The rectangle first side.</param>
        /// <param name="rectangleSecondSide">The rectangle second side.</param>
        /// <param name="color">The color.</param>
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

        /// <summary>
        /// Defines the test method TestPaintMoreThenOneTimePaperShapes.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="squareSide">The square side.</param>
        /// <param name="rectangleFirstSide">The rectangle first side.</param>
        /// <param name="rectangleSecondSide">The rectangle second side.</param>
        /// <param name="color">The color.</param>
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

        /// <summary>
        /// Defines the test method TestCutShapeFromAnotherShape.
        /// </summary>
        /// <param name="smallerRadius">The smaller radius.</param>
        /// <param name="biggerRadius">The bigger radius.</param>
        /// <param name="smallerSide">The smaller side.</param>
        /// <param name="biggerSide">The bigger side.</param>
        /// <param name="smallerFirstSide">The smaller first side.</param>
        /// <param name="smallerSecondSide">The smaller second side.</param>
        /// <param name="biggerFirstSide">The bigger first side.</param>
        /// <param name="biggerSecondSide">The bigger second side.</param>
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


        /// <summary>
        /// Defines the test method TestCutShapeFromAnotherShapeKeepsColor.
        /// </summary>
        /// <param name="smallerRadius">The smaller radius.</param>
        /// <param name="biggerRadius">The bigger radius.</param>
        /// <param name="color">The color.</param>
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

        /// <summary>
        /// Defines the test method TestCutShapeFromAnotherShapeWithAnotherMaterialMustThrowsException.
        /// </summary>
        /// <param name="smallerRadius">The smaller radius.</param>
        /// <param name="biggerRadius">The bigger radius.</param>
        [TestMethod]
        [DataRow(2.3,5.5)]
        public void TestCutShapeFromAnotherShapeWithAnotherMaterialMustThrowsException(double smallerRadius, double biggerRadius)
        {
            //Cutting shape from another shape is available only for equals materials

            PaperCircle bigCircle = new PaperCircle(biggerRadius);
            Assert.ThrowsException<UnableToCutShapeException>(()=>new MembraneCircle(smallerRadius,bigCircle));

        }

        /// <summary>
        /// Defines the test method TestCutShapeFromAnotherShapeWithSmallerAreaMustThrowsException.
        /// </summary>
        /// <param name="smallerRadius">The smaller radius.</param>
        /// <param name="biggerRadius">The bigger radius.</param>
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
