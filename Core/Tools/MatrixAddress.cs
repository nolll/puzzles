using System;

namespace Core.Tools
{
    public class MatrixAddress
    {
        public int X { get; }
        public int Y { get; }
        public string Id { get; }

        public MatrixAddress(int x, int y)
        {
            X = x;
            Y = y;
            Id = $"{x},{y}";
        }

        public int ManhattanDistanceTo(MatrixAddress other)
        {
            var xMax = Math.Max(X, other.X);
            var xMin = Math.Min(X, other.X);
            var xDiff = xMax - xMin;

            var yMax = Math.Max(Y, other.Y);
            var yMin = Math.Min(Y, other.Y);
            var yDiff = yMax - yMin;

            return xDiff + yDiff;
        }
    }
}