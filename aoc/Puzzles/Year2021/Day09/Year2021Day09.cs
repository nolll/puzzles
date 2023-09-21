using Aoc.Platform;

namespace Aoc.Puzzles.Year2021.Day09;

public class Year2021Day09 : Puzzle
{
    public override string Title => "Smoke Basin";

    public override PuzzleResult RunPart1()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindLowPointSum(FileInput);
        return new PuzzleResult(result, 591);
    }

    public override PuzzleResult RunPart2()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(FileInput);
        return new PuzzleResult(result, 1113424);
    }
}