using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

[Name("Step Counter")]
public class Aoc202321(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(CountPositionsAfter(input, 64), "c843850a004e76c6cad0745f43786af0");
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    public static long CountPositionsAfter(string s, int steps)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        var start = matrix.FindAddresses('S').First();
        matrix.WriteValueAt(start, '.');
        var lit = new HashSet<MatrixAddress>();
        lit.Add(start);

        for (var i = 0; i < steps; i++)
        {
            var newLit = new HashSet<MatrixAddress>();
            foreach (var litCoord in lit)
            {
                var allAdjacent = matrix.PossibleOrthogonalAdjacentCoordsTo(litCoord);
                foreach (var a in allAdjacent)
                {
                    if (matrix.ReadValueAt(a) != '#')
                    {
                        newLit.Add(a);
                    }
                }
            }

            lit = newLit;
        }
        
        return lit.Count;
    }
}