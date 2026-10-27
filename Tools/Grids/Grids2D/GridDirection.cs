using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{Name}")]
public record GridDirection(char Name, int X, int Y)
{
    public Coord Delta = new(X, Y);
    
    public static readonly GridDirection Up = new(DirectionName.Up, 0, -1);
    public static readonly GridDirection UpRight = new(DirectionName.Up, 1, -1);
    public static readonly GridDirection Right = new(DirectionName.Right, 1, 0);
    public static readonly GridDirection RightDown = new(DirectionName.Right, 1, 1);
    public static readonly GridDirection Down = new(DirectionName.Down, 0, 1);
    public static readonly GridDirection DownLeft = new(DirectionName.Down, -1, 1);
    public static readonly GridDirection Left = new(DirectionName.Left, -1, 0);
    public static readonly GridDirection LeftUp = new(DirectionName.Left, -1, -1);

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

    public GridDirection TurnLeft() => Name switch
    {
        DirectionName.Up => Left,
        DirectionName.Right => Up,
        DirectionName.Down => Right,
        _ => Down
    };

    public GridDirection TurnRight() => Name switch
    {
        DirectionName.Up => Right,
        DirectionName.Right => Down,
        DirectionName.Down => Left,
        _ => Up
    };

    public static readonly List<GridDirection> Orthogonal = [Up, Right, Down, Left];
    public static readonly List<GridDirection> Diagonal = [UpRight, RightDown, DownLeft, LeftUp];
    public static readonly List<GridDirection> All = [Up, UpRight, Right, RightDown, Down, DownLeft, Left, LeftUp];
    public override string ToString() => Name.ToString();
}