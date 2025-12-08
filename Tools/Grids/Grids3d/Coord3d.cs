using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids3d;

[DebuggerDisplay("{X},{Y},{Z}")]
public class Coord3d : IEquatable<Coord3d>
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public string Id { get; }

    public Coord3d(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        Id = $"{x},{y},{z}";
    }

    public int ManhattanDistanceTo(Coord3d other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);
    
    public double EuclideanDistanceTo(Coord3d other) => 
        Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));

    public override string ToString() => $"{X},{Y},{Z}";

    public bool Equals(Coord3d? other)
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
        return Equals((Coord3d)obj);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Z, Id);
}