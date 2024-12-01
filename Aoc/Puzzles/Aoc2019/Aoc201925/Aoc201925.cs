using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201925;

[Name("Cryostasis")]
public class Aoc201925 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var investigationDroid = new InvestigationDroid(input);
        var password = investigationDroid.Run();

        return new PuzzleResult(password, "378fea8b73ddddacf10ae3b5978e47ab");
    }
}