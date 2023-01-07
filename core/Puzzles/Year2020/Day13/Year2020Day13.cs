using Core.Platform;

namespace Core.Puzzles.Year2020.Day13;

public class Year2020Day13 : Puzzle
{
    public override string Title => "Shuttle Search";

    public override PuzzleResult RunPart1()
    {
        var system = new BusScheduler1(FileInput);
        var value = system.GetBusValue();
        return new PuzzleResult(value, 2298);
    }

    public override PuzzleResult RunPart2()
    {
        var system = new BusScheduler2(FileInput);
        var value = system.GetContestMinute();
        return new PuzzleResult(value, 783_685_719_679_632);
    }
}