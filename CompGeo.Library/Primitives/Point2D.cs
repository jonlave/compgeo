using System;

namespace CompGeo.Library.Primitives
{
    public class Point2D : IEquatable<Point2D>
    {
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public double Y { get; set; }

        public bool Equals(Point2D other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other.X.Equals(this.X) && other.Y.Equals(this.Y);
        }

        /// <summary>
        /// Performs a comparison to a peer Point2D object.
        /// </summary>
        /// <param name="v">Point2D object to compare to.</param>
        /// <param name="type">The type of comparison to perform.</param>
        /// <returns>The comparison value.</returns>
        public int CompareTo(Point2D v, PointComparisonType type)
        {
            switch (type)
            {
                case PointComparisonType.CompareX:
                    return X.CompareTo(v.X);
                case PointComparisonType.CompareY:
                    return Y.CompareTo(v.Y);
                case PointComparisonType.CompareXThenY:
                    return X.CompareTo(v.X) != 0 ? X.CompareTo(v.X) : Y.CompareTo(v.Y);
                case PointComparisonType.CompareXThenYReverse:
                    return X.CompareTo(v.X) != 0 ? X.CompareTo(v.X) : v.Y.CompareTo(Y);
                default:
                    return X.CompareTo(v.X);
            }
        }
        
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            Point2D point2d = other as Point2D;
            if (point2d == null)
            {
                return false;
            }

            return point2d.X.Equals(this.X) && point2d.Y.Equals(this.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X.GetHashCode() * 397) ^ this.Y.GetHashCode();
            }
        }

    }
}
