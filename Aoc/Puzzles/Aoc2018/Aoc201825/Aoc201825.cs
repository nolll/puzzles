using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201825;

[Name("Four-Dimensional Adventure")]
public class Aoc201825(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var finder = new ConstellationFinder(input);
        var constellationCount = finder.Find();
        return new PuzzleResult(constellationCount, "d346cc690c1ce3f1e472e11a710e1982");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}