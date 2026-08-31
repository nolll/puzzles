using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{X},{Y}")]
public record Coord(int X, int Y)
{
    public string Id => field ??= $"{X},{Y}";

    public int ManhattanDistanceTo(Coord other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    
    public static Coord Parse(string s)
    {
        var nums = s.Split(',').Select(int.Parse).ToArray();
        return new Coord(nums[0], nums[1]);
    }

    public virtual bool Equals(Coord? other) => X == other?.X && Y == other.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static Coord FromArray(int[] coords) => coords.Length == 2
        ? new Coord(coords[0], coords[1])
        : throw new ArgumentException("Array has to be to length 2");
}