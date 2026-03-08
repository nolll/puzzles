using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201719;

[Name("A Series of Tubes")]
public class Aoc201719 : AocPuzzle
{
    [Puzzle("36064495be39a4cd3633df813ec64919")]
    public string Part1(string input)
    {
        var finder = new TubeRouteFinder(input);
        finder.FindRoute();
        return finder.Route ?? "";
    }

    [Puzzle("b6a57d5dbd470ae22225f4116dc39da0")]
    public int Part2(string input)
    {
        var finder = new TubeRouteFinder(input);
        finder.FindRoute();
        return finder.StepCount;
    }
}