using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202118;

public class Aoc202118 : AocPuzzle
{
    public override string Name => "Snailfish";

    protected override PuzzleResult RunPart1()
    {
        var math = new SnailfishMath();
        var result = math.Sum(InputFile);

        return new PuzzleResult(result.Magnitude, "1d3da7fb83304ae6368c25c4835fb0af");
    }

    protected override PuzzleResult RunPart2()
    {
        var math = new SnailfishMath();
        var result = math.LargestMagnitude(InputFile);

        return new PuzzleResult(result, "a9626bd58c604514d0e274952464ba7d");
    }
}