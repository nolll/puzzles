using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day25;

public class Year2018Day25 : AocPuzzle
{
    public override string Name => "Four-Dimensional Adventure";

    protected override PuzzleResult RunPart1()
    {
        var finder = new ConstellationFinder(InputFile);
        var constellationCount = finder.Find();
        return new PuzzleResult(constellationCount, 375);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}