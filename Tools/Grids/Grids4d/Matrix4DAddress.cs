namespace Pzl.Tools.Grids.Grids4d;

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

    public int ManhattanDistanceTo(Matrix4DAddress other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z) + Math.Abs(W - other.W);

    public bool Equals(Matrix4DAddress? other)
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
        return Equals((Matrix4DAddress) obj);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W, Id);
}