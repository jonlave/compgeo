using System;
using System.Collections.Generic;
using System.Linq;
using CompGeo.Library.Primitives;

namespace CompGeo.Library
{
    public class ConvexHullByGrahamsScan2D : IConvexHull2D
    {
        public Polygon2D CreateConvexHull2D(List<Point2D> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            // ensure that there are at least 3 points
            if (points.Count < 3)
            {
                throw new Exception("There must be at least 3 points for this algorithm to work.");
            }

            // sort the list by x-coordinate and then by y-coordinates
            Point2DComparer vComparer = new Point2DComparer
            {
                ComparisonType = PointComparisonType.CompareXThenY
            };
            points.Sort(vComparer.Compare);

            // Put the points p1 and p2 in a list L-upper, with p1 as the first point.
            List<Point2D> upper = new List<Point2D> {points[0], points[1]};

            // find upper hull points.
            for (int i = 2; i < points.Count; i++)
            {
                // add next point to the list
                upper.Add(points[i]);

                // while the last 3 points don't create a "right turn" and there are at least 2 points in the list
                while (upper.Count > 2 && GeometryUtility.CrossProduct(upper[upper.Count - 3], upper[upper.Count - 2], upper[upper.Count - 1]) > 0)
                {
                    // remove the middle point
                    upper.RemoveAt(upper.Count - 2);
                }
            }

            // find the lower hull points.
            // first add Pn and Pn - 1 into the list
            List<Point2D> lower = new List<Point2D> { points[points.Count - 1], points[points.Count - 2] };

            for (int i = points.Count - 3; i >= 0; i--)
            {
                // add next point to the list
                lower.Add(points[i]);

                // while the last 3 points don't create a "right turn" and there are at least 2 points in the list
                while (lower.Count > 2 && GeometryUtility.CrossProduct(lower[lower.Count - 3], lower[lower.Count - 2], lower[lower.Count - 1]) > 0)
                {
                    // remove the middle point
                    lower.RemoveAt(lower.Count - 2);
                }
            }

            // remove the first and last points of "lower" to avoid duplication with "upper"
            lower.RemoveAt(0);
            lower.RemoveAt(lower.Count - 1);

            // combine lower and upper lists
            List<Point2D> output = upper.ToList();
            output.AddRange(lower);

            return new Polygon2D(output);
        }
    }
}