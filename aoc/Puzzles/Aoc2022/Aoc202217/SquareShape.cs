using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202217;

public class SquareShape : TetrisShape
{
    private readonly MatrixAddress[] _shape = {
        new(0, 0),
        new(0, -1),
        new(1, 0),
        new(1, -1)
    };

    private readonly MatrixAddress[] _left = {
        new(-1, 0),
        new(-1, -1)
    };

    private readonly MatrixAddress[] _right =
    {
        new(2, 0),
        new(2, -1)
    };

    private readonly MatrixAddress[] _down =
    {
        new(0, 1),
        new(1, 1)
    };

    public SquareShape() : base(2, 2)
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