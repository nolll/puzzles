using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201505;

public class Aoc201505 : AocPuzzle
{
    public override string Name => "Doesn't He Have Intern-Elves For This?";

    protected override PuzzleResult RunPart1()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount1(InputFile);
        return new PuzzleResult(niceCount, "9acaaf3fc5bc7b60d024ccf5dee1c098");
    }

    protected override PuzzleResult RunPart2()
    {
        var niceCount = NaughtyOrNiceEvaluator.GetNiceCount2(InputFile);
        return new PuzzleResult(niceCount, "5363390b461681375e68f3cea9b968df");
    }
}