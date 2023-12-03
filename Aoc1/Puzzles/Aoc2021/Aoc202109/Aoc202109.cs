using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202109;

public class Aoc202109 : AocPuzzle
{
    public override string Name => "Smoke Basin";

    protected override PuzzleResult RunPart1()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindLowPointSum(InputFile);
        return new PuzzleResult(result, "de7031e6bc6f92fb3ebea43ee2b3fe27");
    }

    protected override PuzzleResult RunPart2()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(InputFile);
        return new PuzzleResult(result, "1079be915c188387b9068d26a9911fcc");
    }
}