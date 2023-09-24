using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Day18;

public class Year2021Day18 : AocPuzzle
{
    public override string Name => "Snailfish";

    protected override PuzzleResult RunPart1()
    {
        var math = new SnailfishMath();
        var result = math.Sum(InputFile);

        return new PuzzleResult(result.Magnitude, 4417);
    }

    protected override PuzzleResult RunPart2()
    {
        var math = new SnailfishMath();
        var result = math.LargestMagnitude(InputFile);

        return new PuzzleResult(result, 4796);
    }
}