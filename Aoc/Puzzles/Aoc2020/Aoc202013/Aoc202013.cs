using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202013;

[Name("Shuttle Search")]
public class Aoc202013 : AocPuzzle
{
    [Puzzle("22dea96fc3fe7cf98d5ae3e3a29c196a")]
    public PuzzleResult Part1(string input)
    {
        var system = new BusScheduler1(input);
        var value = system.GetBusValue();
        return new PuzzleResult(value);
    }

    [Puzzle("3b77da892f95806bf7e9daa18ede02a0")]
    public long Part2(string input) => new BusScheduler2(input).GetContestMinute();
}