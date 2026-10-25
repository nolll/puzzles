using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Boxed In")]
public class Aquaq11 : AquaqPuzzle
{
    private const char Empty = '.';
    private const char Filled = '#';

    [Puzzle("f8ed67eec68206fe2abe5c3685719e46")]
    public int Solve(string input)
    {
        var areas = Parse(input);

        var overlappingAreas = areas.Where(o => areas.Count(p => p.IsOverlapping(o)) > 1);
        var grid = new Grid<char>(defaultValue: Empty);

        foreach (var area in overlappingAreas)
        {
            for (var x = area.From.X; x < area.To.X; x++)
            {
                for (var y = area.From.Y; y < area.To.Y; y++)
                {
                    grid.WriteValueAt(x, y, Filled);
                }
            }
        }

        return grid.Values.Count(o => o == Filled);
    }

    private static List<TileSquare> Parse(string input) => [.. input.Split(LineBreaks.Single).Skip(1).Select(TileSquare.ParseSquare)];

    private record TileSquare(Coord From, Coord To)
    {
        public bool IsOverlapping(TileSquare other) =>
            IsOverlapping(From.X, To.X, other.From.X, other.To.X) &&
            IsOverlapping(From.Y, To.Y, other.From.Y, other.To.Y);

        private static bool IsOverlapping(int fromA, int toA, int fromB, int toB) => fromA <= toB && toA >= fromB;

        public static TileSquare ParseSquare(string line)
        {
            var (x1, y1, x2, y2) = Numbers.IntsFromString(line);
            return new TileSquare(new Coord(x1, y1), new Coord(x2, y2));
        }
    }
}