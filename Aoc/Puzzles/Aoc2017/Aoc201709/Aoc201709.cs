using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201709;

[Name("Stream Processing")]
public class Aoc201709(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var processor = new StreamProcessor(Input);
        return new PuzzleResult(processor.Score, "bf1171e2cba9455c97359e9a72e8586f");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new StreamProcessor(Input);
        return new PuzzleResult(processor.GarbageCount, "ff9d742fc8ce537c4cc9bfc6414c7ed6");
    }
}