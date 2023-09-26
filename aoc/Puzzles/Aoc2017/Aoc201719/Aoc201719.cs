using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201719;

public class Aoc201719 : AocPuzzle
{
    public override string Name => "A Series of Tubes";

    protected override PuzzleResult RunPart1()
    {
        var finder = new TubeRouteFinder(InputFile);
        finder.FindRoute();
        return new PuzzleResult(finder.Route, "PVBSCMEQHY");
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new TubeRouteFinder(InputFile);
        finder.FindRoute();
        return new PuzzleResult(finder.StepCount, 17_736);
    }
}