using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{X},{Y}")]
public record Coord(int X, int Y)
{
    private string? _id;
    public string Id => _id ??= $"{X},{Y}";

    public int ManhattanDistanceTo(Coord other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    
    public static Coord Parse(string s)
    {
        var nums = s.Split(',').Select(int.Parse).ToArray();
        return new Coord(nums[0], nums[1]);
    }

    public virtual bool Equals(Coord? other) => X == other?.X && Y == other.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}