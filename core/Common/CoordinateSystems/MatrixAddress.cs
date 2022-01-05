using System;
using System.Diagnostics;

namespace Core.Common.CoordinateSystems;

[DebuggerDisplay("{X},{Y}")]
public class MatrixAddress : IEquatable<MatrixAddress>
{
    private string _id;
        
    public int X { get; }
    public int Y { get; }
    public string Id => _id ??= $"{X},{Y}";

    public MatrixAddress(int x, int y)
    {
        X = x;
        Y = y;
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

    public bool Equals(MatrixAddress other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MatrixAddress)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}