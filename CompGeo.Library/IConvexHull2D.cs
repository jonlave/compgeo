using System.Collections.Generic;
using CompGeo.Library.Primitives;

namespace CompGeo.Library
{
    public interface IConvexHull2D
    {
        Polygon2D CreateConvexHull2D(List<Point2D> points);
    }
}