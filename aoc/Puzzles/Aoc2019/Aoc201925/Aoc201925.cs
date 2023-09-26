using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201925;

public class Aoc201925 : AocPuzzle
{
    public override string Name => "Cryostasis";

    protected override PuzzleResult RunPart1()
    {
        var investigationDroid = new InvestigationDroid(InputFile);
        var password = investigationDroid.Run();

        return new PuzzleResult(password, "285213704");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}