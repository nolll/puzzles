using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202115;

public class Aoc202115 : AocPuzzle
{
    public override string Name => "Chiton";

    protected override PuzzleResult RunPart1()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForSmallCave(InputFile);

        return new PuzzleResult(result, 423);
    }

    protected override PuzzleResult RunPart2()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForLargeCave(InputFile);

        return new PuzzleResult(result, 2778);
    }
}