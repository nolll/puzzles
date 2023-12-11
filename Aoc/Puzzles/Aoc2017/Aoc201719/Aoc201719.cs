using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201719;

[Name("A Series of Tubes")]
public class Aoc201719(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var finder = new TubeRouteFinder(Input);
        finder.FindRoute();
        return new PuzzleResult(finder.Route, "36064495be39a4cd3633df813ec64919");
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new TubeRouteFinder(Input);
        finder.FindRoute();
        return new PuzzleResult(finder.StepCount, "b6a57d5dbd470ae22225f4116dc39da0");
    }
}