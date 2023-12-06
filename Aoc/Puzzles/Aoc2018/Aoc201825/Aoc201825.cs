using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201825;

public class Aoc201825 : AocPuzzle
{
    public override string Name => "Four-Dimensional Adventure";

    protected override PuzzleResult RunPart1()
    {
        var finder = new ConstellationFinder(InputFile);
        var constellationCount = finder.Find();
        return new PuzzleResult(constellationCount, "d346cc690c1ce3f1e472e11a710e1982");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}