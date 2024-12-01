using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202013;

[Name("Shuttle Search")]
public class Aoc202013 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var system = new BusScheduler1(input);
        var value = system.GetBusValue();
        return new PuzzleResult(value, "22dea96fc3fe7cf98d5ae3e3a29c196a");
    }

    public PuzzleResult RunPart2(string input)
    {
        var system = new BusScheduler2(input);
        var value = system.GetContestMinute();
        return new PuzzleResult(value, "3b77da892f95806bf7e9daa18ede02a0");
    }
}