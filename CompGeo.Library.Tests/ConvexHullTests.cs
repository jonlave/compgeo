using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompGeo.Library.Tests
{
    [TestClass]
    public class ConvexHullTests
    {
        [TestMethod]
        public void CreateConvexHullTest()
        {
            IConvexHull2D convexHull2D = new ConvexHullByGrahamsScan2D();
        }
    }
}
