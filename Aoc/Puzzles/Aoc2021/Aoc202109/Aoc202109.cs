using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202109;

[Name("Smoke Basin")]
public class Aoc202109 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindLowPointSum(input);
        return new PuzzleResult(result, "de7031e6bc6f92fb3ebea43ee2b3fe27");
    }

    public PuzzleResult RunPart2(string input)
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(input);
        return new PuzzleResult(result, "1079be915c188387b9068d26a9911fcc");
    }
}