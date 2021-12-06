using System;

namespace ConsoleApp.Puzzles.Year2018.Day23
{
    public class Point3d
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Point3d(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int ManhattanDistanceTo(Point3d other)
        {
            return ManhattanDistanceTo(other.X, other.Y, other.Z);
        }

        public int ManhattanDistanceTo(int x, int y, int z)
        {
            var xMax = Math.Max(X, x);
            var xMin = Math.Min(X, x);
            var xDiff = xMax - xMin;

            var yMax = Math.Max(Y, y);
            var yMin = Math.Min(Y, y);
            var yDiff = yMax - yMin;

            var zMax = Math.Max(Z, z);
            var zMin = Math.Min(Z, z);
            var zDiff = zMax - zMin;

            return xDiff + yDiff + zDiff;
        }
    }
}