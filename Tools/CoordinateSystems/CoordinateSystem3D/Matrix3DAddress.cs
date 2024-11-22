using System.Diagnostics;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

[DebuggerDisplay("{X},{Y},{Z}")]
public class Matrix3DAddress : IEquatable<Matrix3DAddress>
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public string Id { get; }

    public Matrix3DAddress(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        Id = $"{x},{y},{z}";
    }

    public int ManhattanDistanceTo(Matrix3DAddress other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);

    public override string ToString() => $"{X},{Y},{Z}";

    public bool Equals(Matrix3DAddress? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y && Z == other.Z && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Matrix3DAddress)obj);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Z, Id);
}