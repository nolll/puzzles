namespace Pzl.Tools.Grids.Grids4d;

public class Coord4d : IEquatable<Coord4d>
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public int W { get; }
    public string Id { get; }

    public Coord4d(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
        Id = $"{x},{y},{z},{w}";
    }

    public int ManhattanDistanceTo(Coord4d other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z) + Math.Abs(W - other.W);

    public bool Equals(Coord4d? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y && Z == other.Z && W == other.W && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Coord4d) obj);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W, Id);
}