using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class VerticalLineShape : TetrisShape
{
    private readonly Coord[] _shape = {
        new(0, 0),
        new(0, -1),
        new(0, -2),
        new(0, -3)
    };

    private readonly Coord[] _left = {
        new(-1, 0),
        new(-1, -1),
        new(-1, -2),
        new(-1, -3)
    };

    private readonly Coord[] _right =
    {
        new(1, 0),
        new(1, -1),
        new(1, -2),
        new(1, -3)
    };

    private readonly Coord[] _down =
    {
        new(0, 1)
    };

    public VerticalLineShape() : base(1, 4)
    {
    }

    public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
    {
        return CheckCoords(grid, bottomLeft, _left);
    }

    public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
    {
        return CheckCoords(grid, bottomLeft, _right);
    }

    public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
    {
        return CheckCoords(grid, bottomLeft, _down);
    }

    public override void Paint(Grid<char> grid, Coord bottomLeft)
    {
        Paint(grid, bottomLeft, _shape);
    }
}