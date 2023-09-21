using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day25;

public class Year2019Day25 : AocPuzzle
{
    public override string Title => "Cryostasis";

    public override PuzzleResult RunPart1()
    {
        var investigationDroid = new InvestigationDroid(FileInput);
        var password = investigationDroid.Run();

        return new PuzzleResult(password, "285213704");
    }

    public override PuzzleResult RunPart2() => PuzzleResult.Empty;
}