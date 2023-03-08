using Core.Common.CoordinateSystems.CoordinateSystem2D;
using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2022.Day17;

public abstract class TetrisShape
{
    public int Width { get; }
    public int Height { get; }

    protected TetrisShape(int width, int height)
    {
        Width = width;
        Height = height;
    }

    private static IEnumerable<MatrixAddress> TranslateCoords(MatrixAddress baseCoord, IEnumerable<MatrixAddress> deltas)
    {
        return deltas.Select(o => new MatrixAddress(baseCoord.X + o.X, baseCoord.Y + o.Y));
    }

    protected static bool CheckCoords(Matrix<char> matrix, MatrixAddress bottomLeft, IEnumerable<MatrixAddress> deltas)
    {
        var coords = deltas.Select(o => new MatrixAddress(bottomLeft.X + o.X, bottomLeft.Y + o.Y));
        return coords.All(o => !matrix.IsOutOfRange(o) && matrix.ReadValueAt(o) == '.');
    }

    public abstract bool CanMoveLeft(Matrix<char> matrix, MatrixAddress bottomLeft);
    public abstract bool CanMoveRight(Matrix<char> matrix, MatrixAddress bottomLeft);
    public abstract bool CanMoveDown(Matrix<char> matrix, MatrixAddress bottomLeft);
    public abstract void Paint(Matrix<char> matrix, MatrixAddress bottomLeft);

    protected static void Paint(Matrix<char> matrix, MatrixAddress bottomLeft, IEnumerable<MatrixAddress> deltas)
    {
        var coords = TranslateCoords(bottomLeft, deltas);
        foreach (var coord in coords)
        {
            matrix.WriteValueAt(coord, '#');
        }
    }

    public static readonly TetrisShape VerticalLine = new VerticalLineShape();
    public static readonly TetrisShape Plus = new PlusShape();
    public static readonly TetrisShape ReversedL = new ReversedLShape();
    public static readonly TetrisShape HorizontalLine = new HorizontalLineShape();
    public static readonly TetrisShape Square = new SquareShape();
}