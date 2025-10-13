using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{Name}")]
public class GridDirection : IEquatable<GridDirection>
{
    public char Name { get; }
    public int X { get; }
    public int Y { get; }

    private GridDirection(char name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public static readonly GridDirection Up = new(DirectionName.Up, 0, -1);
    public static readonly GridDirection Right = new(DirectionName.Right, 1, 0);
    public static readonly GridDirection Down = new(DirectionName.Down, 0, 1);
    public static readonly GridDirection Left = new(DirectionName.Left, -1, 0);

    public static GridDirection Get(char dir) => dir switch
    {
        DirectionName.Up => Up,
        DirectionName.Right => Right,
        DirectionName.Down => Down,
        _ => Left
    };
    
    public GridDirection Opposite => Name switch
    {
        DirectionName.Up => Down,
        DirectionName.Right => Left,
        DirectionName.Down => Up,
        _ => Right
    };
    
    public static readonly List<GridDirection> All = [Up, Right, Down, Left];

    public bool Equals(GridDirection? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GridDirection)obj);
    }

    public override int GetHashCode() => Name.GetHashCode();
    public override string ToString() => Name.ToString();
}