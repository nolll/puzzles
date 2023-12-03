using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201624;

public class Aoc201624 : AocPuzzle
{
    private AirDuctNavigator Navigator => new(InputFile);

    public override string Name => "Air Duct Spelunking";

    protected override PuzzleResult RunPart1()
    {
        var shortestPath = Navigator.Run(false);
        return new PuzzleResult(shortestPath, "573c0267baa35fb5a2a80250ac4d8775");
    }

    protected override PuzzleResult RunPart2()
    {
        var shortestPath = Navigator.Run(true);
        return new PuzzleResult(shortestPath, "5d497a617fb2aecf0d9e02ee07665b4e");
    }
}