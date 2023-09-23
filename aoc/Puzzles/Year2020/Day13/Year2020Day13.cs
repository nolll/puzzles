using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day13;

public class Year2020Day13 : AocPuzzle
{
    public override string Name => "Shuttle Search";

    protected override PuzzleResult RunPart1()
    {
        var system = new BusScheduler1(InputFile);
        var value = system.GetBusValue();
        return new PuzzleResult(value, 2298);
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new BusScheduler2(InputFile);
        var value = system.GetContestMinute();
        return new PuzzleResult(value, 783_685_719_679_632);
    }
}