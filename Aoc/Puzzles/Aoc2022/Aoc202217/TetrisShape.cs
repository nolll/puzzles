using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public abstract class TetrisShape
{
    public int Width { get; }
    public int Height { get; }

    protected TetrisShape(int width, int height)
    {
        Width = width;
        Height = height;
    }

    private static IEnumerable<Coord> TranslateCoords(Coord baseCoord, IEnumerable<Coord> deltas)
    {
        return deltas.Select(o => new Coord(baseCoord.X + o.X, baseCoord.Y + o.Y));
    }

    protected static bool CheckCoords(Matrix<char> matrix, Coord bottomLeft, IEnumerable<Coord> deltas)
    {
        var coords = deltas.Select(o => new Coord(bottomLeft.X + o.X, bottomLeft.Y + o.Y));
        return coords.All(o => !matrix.IsOutOfRange(o) && matrix.ReadValueAt(o) == '.');
    }

    public abstract bool CanMoveLeft(Matrix<char> matrix, Coord bottomLeft);
    public abstract bool CanMoveRight(Matrix<char> matrix, Coord bottomLeft);
    public abstract bool CanMoveDown(Matrix<char> matrix, Coord bottomLeft);
    public abstract void Paint(Matrix<char> matrix, Coord bottomLeft);

    protected static void Paint(Matrix<char> matrix, Coord bottomLeft, IEnumerable<Coord> deltas)
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