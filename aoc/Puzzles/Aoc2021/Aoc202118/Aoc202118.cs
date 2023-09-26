using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202118;

public class Aoc202118 : AocPuzzle
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