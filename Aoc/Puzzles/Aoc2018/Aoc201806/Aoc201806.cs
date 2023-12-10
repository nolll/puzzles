using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201806;

[Name("Chronal Coordinates")]
public class Aoc201806 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var finder = new LargestAreaFinder(InputFile);
        var size = finder.GetSizeOfLargestArea();
        return new PuzzleResult(size, "38a2162984fb4f3ad26481fe9d035149");
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new LargestAreaFinder(InputFile);
        var size = finder.GetSizeOfCentralArea(10000);
        return new PuzzleResult(size, "1272f4319b022610a3eb7f805e2fba48");
    }
}