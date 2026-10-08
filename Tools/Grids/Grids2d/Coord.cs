using System.Diagnostics;
using Pzl.Tools.Lists;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{X},{Y}")]
public record Coord(int X, int Y)
{
    public string Id => field ??= $"{X},{Y}";

    public Coord((int x, int y) tuple) : this(tuple.x, tuple.y)
    {
    }
    
    public Coord(int[] values) : this(values[0], values[1])
    {
    }
    
    public int ManhattanDistanceTo(Coord other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    
    public static Coord Parse(string s)
    {
        var (x, y) = s.Split(',').Select(int.Parse).ToArray();
        return new Coord(x, y);
    }

    public virtual bool Equals(Coord? other) => X == other?.X && Y == other.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}