using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201804;

public class Aoc201804 : AocPuzzle
{
    public override string Name => "Repose Record";

    protected override PuzzleResult RunPart1()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(InputFile);
        return new PuzzleResult(guardSleepPuzzle.StrategyOneScore, "5eac1b2a363e9607b7231acb68a5d38b");
    }

    protected override PuzzleResult RunPart2()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(InputFile);
        return new PuzzleResult(guardSleepPuzzle.StrategyTwoScore, "8b909b46ebe2d7587152380781205c23");
    }
}