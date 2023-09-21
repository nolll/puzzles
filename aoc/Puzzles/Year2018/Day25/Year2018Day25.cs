using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day25;

public class Year2018Day25 : AocPuzzle
{
    public override string Title => "Four-Dimensional Adventure";

    public override PuzzleResult RunPart1()
    {
        var finder = new ConstellationFinder(FileInput);
        var constellationCount = finder.Find();
        return new PuzzleResult(constellationCount, 375);
    }

    public override PuzzleResult RunPart2() => PuzzleResult.Empty;
}