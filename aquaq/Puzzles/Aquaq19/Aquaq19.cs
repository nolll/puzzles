using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq19;

public class Aquaq19 : AquaqPuzzle
{
    private const char Filled = '#';
    private const char Empty = '.';

    public override string Name => "It's alive";

    protected override PuzzleResult Run()
    {
        var result = InputFile.Split(Environment.NewLine)
            .Select(RunGame).Sum();

        return new PuzzleResult(result, 2481);
    }

    public static int RunGame(string s)
    {
        var parts = s.Split(' ');
        var iterations = int.Parse(parts[0]);
        var size = int.Parse(parts[1]);
        var points = new List<MatrixAddress>();
        for (var i = 2; i < parts.Length; i += 2)
        {
            points.Add(new MatrixAddress(int.Parse(parts[i + 1]), int.Parse(parts[i])));
        }

        var matrix = new Matrix<char>(size, size, Empty);
        foreach (var point in points)
        {
            matrix.WriteValueAt(point, Filled);
        }

        for (var i = 0; i < iterations; i++)
        {
            var newMatrix = matrix.Copy();
            foreach (var address in matrix.Coords)
            {
                var adjacentValues = matrix.PerpendicularAdjacentValuesTo(address);
                var countFilled = adjacentValues.Count(o => o == Filled);
                var isEven = countFilled % 2 == 0;
                var v = isEven ? Empty : Filled;
                newMatrix.WriteValueAt(address, v);
            }
            matrix = newMatrix;
        }

        var result = matrix.Values.Count(o => o == Filled);
        
        //Console.WriteLine();
        //Console.WriteLine($"{s}: {result}");
        
        return result;
    }
}