using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201708;

[Name("I Heard You Like Registers")]
public class Aoc201708 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var calculator = new CpuInstructionCalculator(input);
        return new PuzzleResult(calculator.LargestValueAtEnd, "3c0ff36b6914cd6851601f65f68e9637");
    }

    public PuzzleResult RunPart2(string input)
    {
        var calculator = new CpuInstructionCalculator(input);
        return new PuzzleResult(calculator.LargestValueEver, "e2ede6d54359a751cf2c2bdae941840b");
    }
}