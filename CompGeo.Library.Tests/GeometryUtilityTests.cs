using System;
using CompGeo.Library.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompGeo.Library.Tests
{
    [TestClass]
    public class GeometryUtilityTests
    {
        [TestMethod]
        public void CrossProductTest()
        {
            Point2D p1 = new Point2D(3, 3);
            Point2D p2 = new Point2D(4, 4);
            Point2D p3 = new Point2D(4, 5);
            Point2D p4 = new Point2D(5, 4);
            Point2D p5 = new Point2D(5, 5);

            // test that left turn has positive sign
            double result = GeometryUtility.CrossProduct(p1, p2, p3);
            Assert.IsTrue(result > 0, string.Format("Cross product result was {0}", result));

            // test that right turn has negative sign
            result = GeometryUtility.CrossProduct(p1, p2, p4);
            Assert.IsTrue(result < 0, string.Format("Cross product result was {0}", result));

            // test that no turn is zero
            result = GeometryUtility.CrossProduct(p1, p2, p5);
            Assert.IsTrue(result == 0, string.Format("Cross product result was {0}", result));
        }

    }
}
