using System;

namespace Core.IntersectionFinder
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Distance => Math.Abs(X) + Math.Abs(Y);
    }
}