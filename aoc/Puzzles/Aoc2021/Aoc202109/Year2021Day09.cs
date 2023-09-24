using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202109;

public class Year2021Day09 : AocPuzzle
{
    public override string Name => "Smoke Basin";

    protected override PuzzleResult RunPart1()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindLowPointSum(InputFile);
        return new PuzzleResult(result, 591);
    }

    protected override PuzzleResult RunPart2()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(InputFile);
        return new PuzzleResult(result, 1113424);
    }
}