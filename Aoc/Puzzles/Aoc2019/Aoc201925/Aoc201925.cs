using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201925;

[Name("Cryostasis")]
public class Aoc201925(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var investigationDroid = new InvestigationDroid(input);
        var password = investigationDroid.Run();

        return new PuzzleResult(password, "378fea8b73ddddacf10ae3b5978e47ab");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}