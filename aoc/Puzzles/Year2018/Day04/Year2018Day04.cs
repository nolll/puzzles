using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day04;

public class Year2018Day04 : AocPuzzle
{
    public override string Title => "Repose Record";

    public override PuzzleResult RunPart1()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
        return new PuzzleResult(guardSleepPuzzle.StrategyOneScore, 87_681);
    }

    public override PuzzleResult RunPart2()
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
        return new PuzzleResult(guardSleepPuzzle.StrategyTwoScore, 136_461);
    }
}