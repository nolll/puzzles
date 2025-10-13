using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202410;

[Name("Hoof It")]
public class Aoc202410 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        var trailHeads = matrix.FindAddresses(0);
        var totalScore = trailHeads.Sum(trailHead => CountPaths(matrix, trailHead, []));

        return new PuzzleResult(totalScore, "6149f23d412a8b5869010747e43f41ea");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        var trailHeads = matrix.FindAddresses(0);
        var totalScore = trailHeads.Sum(trailHead => CountPaths(matrix, trailHead));

        return new PuzzleResult(totalScore, "9f0c79d76028ec84f2fda12a86e15c52");
    }

    private static int CountPaths(Matrix<int> matrix, MatrixAddress coord, HashSet<MatrixAddress>? seen = null)
    {
        var v = matrix.ReadValueAt(coord);
        seen?.Add(coord);

        if (v == 9)
            return 1;
        
        var neighbors = matrix.OrthogonalAdjacentCoordsTo(coord)
            .Where(o => matrix.ReadValueAt(o) == v + 1);
        if (seen is not null)
            neighbors = neighbors.Where(o => !seen.Contains(o));

        return neighbors.Sum(neighbor => CountPaths(matrix, neighbor, seen));
    }
}