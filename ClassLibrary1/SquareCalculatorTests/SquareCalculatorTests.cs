using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SquareCalculator.SquareCalculator;

namespace SquareCalculatorTests
{
    [TestClass]
    public class SquareCalculatorTests
    {
        [TestMethod]
        public void CirclesSquareTest()
        {
            double testRadius = 4.564;
            Circle testCircle = new Circle(testRadius);

            Assert.AreEqual(testCircle.GetSquare(), Math.Pow(testRadius, 2) * Math.PI);

        }

        [TestMethod]
        public void TrianglesSquareTest()
        {
            double testFirstSide = 5;
            double testSecondSide = 9;
            double testThirdSide = 7;
            Triangle testTriangle = new Triangle(testFirstSide, testSecondSide, testThirdSide);
            double testHalfOfPerimeter = 0.5 * (testFirstSide + testSecondSide + testThirdSide);

            double expectedSquare = Math.Sqrt(testHalfOfPerimeter * (testHalfOfPerimeter - testFirstSide) * (testHalfOfPerimeter - testSecondSide) * (testHalfOfPerimeter - testThirdSide));

            Assert.AreEqual(testTriangle.GetSquare(), expectedSquare);
        }
    }
}
