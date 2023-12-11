using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201807;

[Name("The Sum of Its Parts")]
public class Aoc201807(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var assembler1 = new SleighAssembler(Input, 1, 0);
        var result1 = assembler1.Assemble();
        return new PuzzleResult(result1.Order, "ed793c91fc1d9c9e6a4828232e0a8c2b");
    }

    protected override PuzzleResult RunPart2()
    {
        var assembler2 = new SleighAssembler(Input, 5, 60);
        var result2 = assembler2.Assemble();
        return new PuzzleResult(result2.Time, "c0599783d1840d6a6a7350bc40af4377");
    }
}