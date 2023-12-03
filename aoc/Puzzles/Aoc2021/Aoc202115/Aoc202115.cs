using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202115;

public class Aoc202115 : AocPuzzle
{
    public override string Name => "Chiton";

    protected override PuzzleResult RunPart1()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForSmallCave(InputFile);

        return new PuzzleResult(result, "044f1b14974612cad17255d7683d0892");
    }

    protected override PuzzleResult RunPart2()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForLargeCave(InputFile);

        return new PuzzleResult(result, "99cda5f07b0381340587915a1e9f5cb2");
    }
}