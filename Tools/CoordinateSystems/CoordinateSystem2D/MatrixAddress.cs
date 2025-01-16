using System.Diagnostics;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

[DebuggerDisplay("{X},{Y}")]
public class MatrixAddress(int x, int y) : IEquatable<MatrixAddress>
{
    private string? _id;
    private (int, int)? _tuple;
        
    public int X { get; } = x;
    public int Y { get; } = y;
    public string Id => _id ??= $"{X},{Y}";
    public (int x, int y) Tuple => _tuple ??= (X, Y);

    public int ManhattanDistanceTo(MatrixAddress other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    
    public static MatrixAddress Parse(string s)
    {
        var nums = s.Split(',').Select(int.Parse).ToArray();
        return new MatrixAddress(nums[0], nums[1]);
    }

    public bool Equals(MatrixAddress? other)
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
        return Equals((MatrixAddress)obj);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}