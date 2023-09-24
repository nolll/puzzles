using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day24;

public class Year2016Day24 : AocPuzzle
{
    private AirDuctNavigator Navigator => new(InputFile);

    public override string Name => "Air Duct Spelunking";

    protected override PuzzleResult RunPart1()
    {
        var shortestPath = Navigator.Run(false);
        return new PuzzleResult(shortestPath, 502);
    }

    protected override PuzzleResult RunPart2()
    {
        var shortestPath = Navigator.Run(true);
        return new PuzzleResult(shortestPath, 724);
    }
}