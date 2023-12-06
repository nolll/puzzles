using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201708;

public class Aoc201708 : AocPuzzle
{
    public override string Name => "I Heard You Like Registers";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new CpuInstructionCalculator(InputFile);
        return new PuzzleResult(calculator.LargestValueAtEnd, "3c0ff36b6914cd6851601f65f68e9637");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new CpuInstructionCalculator(InputFile);
        return new PuzzleResult(calculator.LargestValueEver, "e2ede6d54359a751cf2c2bdae941840b");
    }
}