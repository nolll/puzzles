using App.Platform;

namespace App.Puzzles.Year2021.Day15;

public class Year2021Day15 : Puzzle
{
    public override bool IsSlow => true;
    public override bool NeedsRewrite => true;
    public override string Comment => "The matrix code can't handle such a large matrix";

    public override PuzzleResult RunPart1()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForSmallCave(FileInput);

        return new PuzzleResult(result, 423);
    }

    public override PuzzleResult RunPart2()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForLargeCave(FileInput);

        return new PuzzleResult(result, 2778);
    }
}