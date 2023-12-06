using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class ReversedLShape : TetrisShape
{
    private readonly MatrixAddress[] _shape = {
        new(0, 0),
        new(1, 0),
        new(2, 0),
        new(2, -1),
        new(2, -2)
    };

    private readonly MatrixAddress[] _left = {
        new(-1, 0),
        new(1, -1),
        new(1, -2)
    };

    private readonly MatrixAddress[] _right =
    {
        new(3, 0),
        new(3, -1),
        new(3, -2)
    };

    private readonly MatrixAddress[] _down =
    {
        new(0, 1),
        new(1, 1),
        new(2, 1),
    };

    public ReversedLShape() : base(3, 3)
    {
    }

    public override bool CanMoveLeft(Matrix<char> matrix, MatrixAddress bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _left);
    }

    public override bool CanMoveRight(Matrix<char> matrix, MatrixAddress bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _right);
    }

    public override bool CanMoveDown(Matrix<char> matrix, MatrixAddress bottomLeft)
    {
        return CheckCoords(matrix, bottomLeft, _down);
    }

    public override void Paint(Matrix<char> matrix, MatrixAddress bottomLeft)
    {
        Paint(matrix, bottomLeft, _shape);
    }
}