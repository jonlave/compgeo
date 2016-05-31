using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompGeo.Library.Primitives;

namespace CompGeo.Library
{
    public class GeometryUtility
    {
        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="p1">First point.</param>
        /// <param name="p2">Second point.</param>
        /// <returns>The distance between two points.</returns>
        public static double GetDistance(Point2D p1, Point2D p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }

        /// <summary>
        /// Finds the cross product of the 2 vectors created by the 3 vertices.
        /// Vector 1 = v1 -> v2, Vector 2 = v2 -> v3
        /// The vectors make a "right turn" if the sign of the cross product is negative.
        /// The vectors make a "left turn" if the sign of the cross product is positive.
        /// The vectors are colinear (on the same line) if the cross product is zero.
        /// </summary>
        /// <param name="p1">First point.</param>
        /// <param name="p2">Second point.</param>
        /// <param name="p3">Third point.</param>
        /// <returns>Cross product of the two vectors.</returns>
        public static double CrossProduct(Point2D p1, Point2D p2, Point2D p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y);
        }
    }
}
