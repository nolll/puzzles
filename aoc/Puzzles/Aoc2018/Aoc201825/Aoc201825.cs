using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201825;

public class Aoc201825 : AocPuzzle
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