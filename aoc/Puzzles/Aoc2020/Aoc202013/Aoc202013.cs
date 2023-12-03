using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202013;

public class Aoc202013 : AocPuzzle
{
    public override string Name => "Shuttle Search";

    protected override PuzzleResult RunPart1()
    {
        var system = new BusScheduler1(InputFile);
        var value = system.GetBusValue();
        return new PuzzleResult(value, "22dea96fc3fe7cf98d5ae3e3a29c196a");
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new BusScheduler2(InputFile);
        var value = system.GetContestMinute();
        return new PuzzleResult(value, "3b77da892f95806bf7e9daa18ede02a0");
    }
}