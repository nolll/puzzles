using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day06;

public class Year2018Day06 : AocPuzzle
{
    public override string Name => "Chronal Coordinates";

    public override PuzzleResult RunPart1()
    {
        var finder = new LargestAreaFinder(FileInput);
        var size = finder.GetSizeOfLargestArea();
        return new PuzzleResult(size, 3223);
    }

    public override PuzzleResult RunPart2()
    {
        var finder = new LargestAreaFinder(FileInput);
        var size = finder.GetSizeOfCentralArea(10000);
        return new PuzzleResult(size, 40_495);
    }
}