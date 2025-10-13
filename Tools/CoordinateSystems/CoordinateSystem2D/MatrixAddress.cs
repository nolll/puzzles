using System.Diagnostics;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

[DebuggerDisplay("{X},{Y}")]
public record MatrixAddress(int X, int Y)
{
    private string? _id;
    public string Id => _id ??= $"{X},{Y}";

    public int ManhattanDistanceTo(MatrixAddress other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    
    public static MatrixAddress Parse(string s)
    {
        var nums = s.Split(',').Select(int.Parse).ToArray();
        return new MatrixAddress(nums[0], nums[1]);
    }

    public virtual bool Equals(MatrixAddress? other) => X == other?.X && Y == other.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}