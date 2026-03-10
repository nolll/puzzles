using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202115;

[Name("Chiton")]
public class Aoc202115 : AocPuzzle
{
    [Puzzle("044f1b14974612cad17255d7683d0892")]
    public PuzzleResult Part1(string input)
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForSmallCave(input);

        return new PuzzleResult(result);
    }

    [Puzzle("99cda5f07b0381340587915a1e9f5cb2")]
    public PuzzleResult Part2(string input)
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForLargeCave(input);

        return new PuzzleResult(result);
    }
}