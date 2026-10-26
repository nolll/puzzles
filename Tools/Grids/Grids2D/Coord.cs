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
    
    public Coord() : this(0, 0)
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
    
    public Coord Up(int steps = 1) => Forward(GridDirection.Up, steps);
    public Coord Right(int steps = 1) => Forward(GridDirection.Right, steps);
    public Coord Down(int steps = 1) => Forward(GridDirection.Down, steps);
    public Coord Left(int steps = 1) => Forward(GridDirection.Left, steps);
    public Coord Forward(GridDirection direction, int steps = 1) => Direction(direction, steps);
    public Coord Backward(GridDirection direction, int steps = 1) => Direction(direction, -steps);
    public Coord Direction(GridDirection direction, int steps = 1) => new(X + direction.X * steps, Y + direction.Y * steps);
    public Coord Relative(int x, int y) => new(X + x, Y + y);
    public Coord RotateLeft() => new(-Y, X);
    public Coord RotateRight() => new(Y, -X);
    
    public IEnumerable<Coord> OrthogonalAdjacent() => GridConstants.OrthogonalDirections.Select(o => new Coord(X + o.x, Y + o.y));
    public IEnumerable<Coord> DiagonalAdjacent() => GridConstants.DiagonalDirections.Select(o => new Coord(X + o.x, Y + o.y));
    public IEnumerable<Coord> AllAdjacent() => GridConstants.AllDirections.Select(o => new Coord(X + o.x, Y + o.y));
}