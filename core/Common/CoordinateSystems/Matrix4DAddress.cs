using System;

namespace App.Common.CoordinateSystems;

public class Matrix4DAddress : IEquatable<Matrix4DAddress>
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public int W { get; }
    public string Id { get; }

    public Matrix4DAddress(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
        Id = $"{x},{y},{z},{w}";
    }

    public int ManhattanDistanceTo(Matrix4DAddress other)
    {
        var xMax = Math.Max(X, other.X);
        var xMin = Math.Min(X, other.X);
        var xDiff = xMax - xMin;

        var yMax = Math.Max(Y, other.Y);
        var yMin = Math.Min(Y, other.Y);
        var yDiff = yMax - yMin;

        var zMax = Math.Max(Z, other.Z);
        var zMin = Math.Min(Z, other.Z);
        var zDiff = zMax - zMin;

        var wMax = Math.Max(W, other.W);
        var wMin = Math.Min(W, other.W);
        var wDiff = wMax - wMin;

        return xDiff + yDiff + zDiff + wDiff;
    }

    public bool Equals(Matrix4DAddress other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y && Z == other.Z && W == other.W && Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Matrix4DAddress) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W, Id);
    }
}