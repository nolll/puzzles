using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

[DebuggerDisplay("{Name}")]
public record GridDirection(char Name, int X, int Y)
{
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

    public static readonly List<GridDirection> All = [Up, Right, Down, Left];
    public override string ToString() => Name.ToString();
}