using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201624;

[Name("Air Duct Spelunking")]
public class Aoc201624 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var navigator = new AirDuctNavigator(input);
        var shortestPath = navigator.Run(false);
        return new PuzzleResult(shortestPath, "573c0267baa35fb5a2a80250ac4d8775");
    }

    public PuzzleResult RunPart2(string input)
    {
        var navigator = new AirDuctNavigator(input);
        var shortestPath = navigator.Run(true);
        return new PuzzleResult(shortestPath, "5d497a617fb2aecf0d9e02ee07665b4e");
    }
}