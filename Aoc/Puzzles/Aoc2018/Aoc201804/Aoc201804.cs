using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201804;

[Name("Repose Record")]
public class Aoc201804 : AocPuzzle
{
    [Puzzle("5eac1b2a363e9607b7231acb68a5d38b")]
    public int Part1(string input) => new GuardSleepPuzzle(input).StrategyOneScore;

    [Puzzle("8b909b46ebe2d7587152380781205c23")]
    public int Part2(string input) => new GuardSleepPuzzle(input).StrategyTwoScore;
}