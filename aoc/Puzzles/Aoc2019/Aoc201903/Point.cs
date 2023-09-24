using System;

namespace Aoc.Puzzles.Aoc2019.Day03;

public class Point : IEquatable<Point>
{
    public int X { get; }
    public int Y { get; }
    public string Id { get; }
    public int Steps { get; }

    public Point(int x, int y, int steps)
    {
        X = x;
        Y = y;
        Id = $"{X}|{Y}";
        Steps = steps;
    }

    public int Distance => Math.Abs(X) + Math.Abs(Y);

    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }
}