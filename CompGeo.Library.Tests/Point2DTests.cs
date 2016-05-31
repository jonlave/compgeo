using System;
using CompGeo.Library.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompGeo.Library.Tests
{
    [TestClass]
    public class Point2DTests
    {
        [TestMethod]
        public void Point2DEquals_Test1()
        {
            Point2D point1 = new Point2D(1, 6);
            Point2D point2 = new Point2D(1, 6);

            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void Point2DEquals_Test2()
        {
            Point2D point1 = new Point2D(3, -1);
            Point2D point2 = new Point2D(3, -1);

            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void Point2DEquals_Test3()
        {
            Point2D point1 = new Point2D(3, -1);

            Assert.IsTrue(point1.Equals(point1));
        }

        [TestMethod]
        public void Point2DEquals_Test4()
        {
            Point2D point1 = new Point2D(4, -5);
            object point2 = new Point2D(4, -5);

            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void Point2DNotEquals_Test1()
        {
            Point2D point1 = new Point2D(2, -7);
            Point2D point2 = new Point2D(-4, -1);

            Assert.IsTrue(!point1.Equals(point2));
        }

        [TestMethod]
        public void Point2DNotEquals_Test2()
        {
            Point2D point1 = null;
            Point2D point2 = new Point2D(-7, -1);

            Assert.IsTrue(!point2.Equals(point1));
        }
    }
}
