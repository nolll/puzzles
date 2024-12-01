using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201804;

[Name("Repose Record")]
public class Aoc201804 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(input);
        return new PuzzleResult(guardSleepPuzzle.StrategyOneScore, "5eac1b2a363e9607b7231acb68a5d38b");
    }

    public PuzzleResult RunPart2(string input)
    {
        var guardSleepPuzzle = new GuardSleepPuzzle(input);
        return new PuzzleResult(guardSleepPuzzle.StrategyTwoScore, "8b909b46ebe2d7587152380781205c23");
    }
}