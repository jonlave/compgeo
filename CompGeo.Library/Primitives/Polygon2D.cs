using System;
using System.Collections.Generic;

namespace CompGeo.Library.Primitives
{
    public class Polygon2D
    {
        readonly List<Point2D> vertices;

        public Polygon2D()
        {
            vertices = new List<Point2D>();
        }

        public Polygon2D(List<Point2D> initialVertices)
        {
            vertices = initialVertices;
        }

        public int Size
        {
            get
            {
                return vertices.Count;
            }
        }

        public void AddPoint(Point2D point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            vertices.Add(point);
            SortByX();
        }

        public void AddPoints(IEnumerable<Point2D> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            vertices.AddRange(points);
            SortByX();
        }

        public double Area()
        {
            double area = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                int j = (i + 1) % vertices.Count;
                area += vertices[i].X * vertices[j].Y;
                area -= vertices[i].Y * vertices[j].X;
            }

            return area /= 2.0;
        }

        public Point2D Centroid()
        {
            double cx = 0;
            double cy = 0;
            double area = Area();

            for (int i = 0; i < vertices.Count; i++)
            {
                int j = (i + 1) % vertices.Count;

                double factor = vertices[i].X * vertices[j].Y -
                                vertices[i].Y * vertices[j].X;

                cx += (vertices[i].X + vertices[j].X) * factor;
                cy += (vertices[i].Y + vertices[j].Y) * factor;
            }

            cx = cx / (6 * area);
            cy = cy / (6 * area);

            return new Point2D(cx, cy);
        }

        private void SortByX()
        {
            Point2DComparer vComparer = new Point2DComparer { ComparisonType = PointComparisonType.CompareX };

            vertices.Sort(vComparer.Compare);
        }
    }
}
