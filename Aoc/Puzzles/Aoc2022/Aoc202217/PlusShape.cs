using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class PlusShape : TetrisShape
{
    private readonly Coord[] _shape = {
        new(1, 0),
        new(1, -1),
        new(1, -2),
        new(0, -1),
        new(2, -1)
    };

    private readonly Coord[] _left = {
        new(0, -2),
        new(-1, -1),
        new(0, 0)
    };

    private readonly Coord[] _right =
    {
        new(2, -2),
        new(3, -1),
        new(2, 0)
    };

    private readonly Coord[] _down =
    {
        new(0, 0),
        new(1, 1),
        new(2, 0)
    };

    public PlusShape() : base(3, 3)
    {
    }

    public override bool CanMoveLeft(Matrix<char> matrix, Coord bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _left);
    }

    public override bool CanMoveRight(Matrix<char> matrix, Coord bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _right);
    }

    public override bool CanMoveDown(Matrix<char> matrix, Coord bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _down);
    }

    public override void Paint(Matrix<char> matrix, Coord bottomLeft)
    {
        Paint(matrix, bottomLeft, _shape);
    }
}