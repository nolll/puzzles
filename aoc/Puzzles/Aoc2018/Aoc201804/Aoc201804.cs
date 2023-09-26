using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201804;

public class Aoc201804 : AocPuzzle
{
    public override string Name => "Repose Record";

    protected override PuzzleResult RunPart1()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(InputFile);
        return new PuzzleResult(guardSleepPuzzle.StrategyOneScore, 87_681);
    }

    protected override PuzzleResult RunPart2()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(InputFile);
        return new PuzzleResult(guardSleepPuzzle.StrategyTwoScore, 136_461);
    }
}