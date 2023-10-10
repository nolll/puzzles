using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq27;

public class Aquaq27 : AquaqPuzzle
{
    private const char Empty = ' ';

    public override string Name => "Snake Eater";

    protected override PuzzleResult Run()
    {
        throw new NotImplementedException();
    }

    public static int CalculateSnakeScore(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, Empty);
        var coordsWithChars = matrix.Coords.Where(o => matrix.ReadValueAt(o) != Empty);
        var ends = coordsWithChars.Where(o => matrix.PerpendicularAdjacentCoordsTo(o).Count == 1);
        

        var sum = 0;
        foreach (var coord in coordsWithChars)
        {
            var c = matrix.ReadValueAt(coord);
            var adjacentLetterCount = matrix.PerpendicularAdjacentValuesTo(coord).Count(o => o != Empty);
            sum += GetCharScore(c) * adjacentLetterCount;
        }

        return sum;
    }

    private static int GetCharScore(char c)
    {
        return (int)(c - 'a') + 1;
    }
}