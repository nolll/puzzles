using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq11;

[Name("Boxed In")]
public class Aquaq11(string input) : AquaqPuzzle
{
    private const char Empty = '.';
    private const char Filled = '#';

    protected override PuzzleResult Run()
    {
        var result = CountRequiredTiles(input);

        return new PuzzleResult(result, "f8ed67eec68206fe2abe5c3685719e46");
    }

    public static int CountRequiredTiles(string input)
    {
        var areas = StringReader.ReadLines(input)
            .Skip(1)
            .Select(line => line.Split(',').Select(int.Parse).ToArray())
            .Select(o => new TileSquare(new MatrixAddress(o[0], o[1]), new MatrixAddress(o[2], o[3])))
            .ToList();

        var overlappingAreas = areas.Where(o => areas.Count(p => p.IsOverlapping(o)) > 1);

        var matrix = new Matrix<char>(defaultValue: Empty);

        foreach (var area in overlappingAreas)
        {
            for (var x = area.From.X; x < area.To.X; x++)
            {
                for (var y = area.From.Y; y < area.To.Y; y++)
                {
                    matrix.WriteValueAt(x, y, Filled);
                }
            }
        }

        return matrix.Values.Count(o => o == Filled);
    }

    private class TileSquare
    {
        public MatrixAddress From { get; }
        public MatrixAddress To { get; }

        public TileSquare(MatrixAddress from, MatrixAddress to)
        {
            From = from;
            To = to;
        }

        public bool IsOverlapping(TileSquare other) =>
            IsOverlapping(From.X, To.X, other.From.X, other.To.X) &&
            IsOverlapping(From.Y, To.Y, other.From.Y, other.To.Y);

        private static bool IsOverlapping(int fromA, int toA, int fromB, int toB)
            => (fromA <= toB && toA >= fromB);
    }
}