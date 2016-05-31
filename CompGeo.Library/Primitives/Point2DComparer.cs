using System.Collections;
using System.Collections.Generic;

namespace CompGeo.Library.Primitives
{
    internal class Point2DComparer : IComparer<Point2D>
    {
        public PointComparisonType ComparisonType { get; set; }

        public int Compare(Point2D p1, Point2D p2)
        {
            return p1.CompareTo(p2, this.ComparisonType);
        }

    }
}