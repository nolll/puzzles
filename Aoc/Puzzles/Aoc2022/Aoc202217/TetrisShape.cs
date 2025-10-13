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

    protected static bool CheckCoords(Grid<char> grid, Coord bottomLeft, IEnumerable<Coord> deltas)
    {
        var coords = deltas.Select(o => new Coord(bottomLeft.X + o.X, bottomLeft.Y + o.Y));
        return coords.All(o => !grid.IsOutOfRange(o) && grid.ReadValueAt(o) == '.');
    }

    public abstract bool CanMoveLeft(Grid<char> grid, Coord bottomLeft);
    public abstract bool CanMoveRight(Grid<char> grid, Coord bottomLeft);
    public abstract bool CanMoveDown(Grid<char> grid, Coord bottomLeft);
    public abstract void Paint(Grid<char> grid, Coord bottomLeft);

    protected static void Paint(Grid<char> grid, Coord bottomLeft, IEnumerable<Coord> deltas)
    {
        var coords = TranslateCoords(bottomLeft, deltas);
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, '#');
        }
    }

    public static readonly TetrisShape VerticalLine = new VerticalLineShape();
    public static readonly TetrisShape Plus = new PlusShape();
    public static readonly TetrisShape ReversedL = new ReversedLShape();
    public static readonly TetrisShape HorizontalLine = new HorizontalLineShape();
    public static readonly TetrisShape Square = new SquareShape();
}