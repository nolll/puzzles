using System.Diagnostics;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

[DebuggerDisplay("{Name}")]
public class MatrixDirection : IEquatable<MatrixDirection>
{
    public char Name { get; }
    public int X { get; }
    public int Y { get; }

    private MatrixDirection(char name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public static readonly MatrixDirection Up = new(DirectionName.Up, 0, -1);
    public static readonly MatrixDirection Right = new(DirectionName.Right, 1, 0);
    public static readonly MatrixDirection Down = new(DirectionName.Down, 0, 1);
    public static readonly MatrixDirection Left = new(DirectionName.Left, -1, 0);

    public static MatrixDirection Get(char dir) => dir switch
    {
        DirectionName.Up => Up,
        DirectionName.Right => Right,
        DirectionName.Down => Down,
        _ => Left
    };
    
    public MatrixDirection Opposite => Name switch
    {
        DirectionName.Up => Down,
        DirectionName.Right => Left,
        DirectionName.Down => Up,
        _ => Right
    };
    
    public static readonly List<MatrixDirection> All = [Up, Right, Down, Left];

    public bool Equals(MatrixDirection? other)
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
        return Equals((MatrixDirection)obj);
    }

    public override int GetHashCode() => Name.GetHashCode();
    public override string ToString() => Name.ToString();
}