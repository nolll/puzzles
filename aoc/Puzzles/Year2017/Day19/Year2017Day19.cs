using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day19;

public class Year2017Day19 : AocPuzzle
{
    public override string Name => "A Series of Tubes";

    public override PuzzleResult RunPart1()
    {
        var finder = new TubeRouteFinder(FileInput);
        finder.FindRoute();
        return new PuzzleResult(finder.Route, "PVBSCMEQHY");
    }

    public override PuzzleResult RunPart2()
    {
        var finder = new TubeRouteFinder(FileInput);
        finder.FindRoute();
        return new PuzzleResult(finder.StepCount, 17_736);
    }
}