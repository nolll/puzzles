using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class HorizontalLineShape : TetrisShape
{
    private readonly Coord[] _shape = {
        new(0, 0),
        new(1, 0),
        new(2, 0),
        new(3, 0)
    };

    private readonly Coord[] _left = {
        new(-1, 0)
    };

    private readonly Coord[] _right =
    {
        new(4, 0)
    };

    private readonly Coord[] _down =
    {
        new(0, 1),
        new(1, 1),
        new(2, 1),
        new(3, 1)
    };

    public HorizontalLineShape() : base(4, 1)
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