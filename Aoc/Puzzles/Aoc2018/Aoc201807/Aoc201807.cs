using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201807;

[Name("The Sum of Its Parts")]
public class Aoc201807 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var assembler1 = new SleighAssembler(input, 1, 0);
        var result1 = assembler1.Assemble();
        return new PuzzleResult(result1.Order, "ed793c91fc1d9c9e6a4828232e0a8c2b");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var assembler2 = new SleighAssembler(input, 5, 60);
        var result2 = assembler2.Assemble();
        return new PuzzleResult(result2.Time, "c0599783d1840d6a6a7350bc40af4377");
    }
}