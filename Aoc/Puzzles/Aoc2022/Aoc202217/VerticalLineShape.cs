using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class VerticalLineShape : TetrisShape
{
    private readonly MatrixAddress[] _shape = {
        new(0, 0),
        new(0, -1),
        new(0, -2),
        new(0, -3)
    };

    private readonly MatrixAddress[] _left = {
        new(-1, 0),
        new(-1, -1),
        new(-1, -2),
        new(-1, -3)
    };

    private readonly MatrixAddress[] _right =
    {
        new(1, 0),
        new(1, -1),
        new(1, -2),
        new(1, -3)
    };

    private readonly MatrixAddress[] _down =
    {
        new(0, 1)
    };

    public VerticalLineShape() : base(1, 4)
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