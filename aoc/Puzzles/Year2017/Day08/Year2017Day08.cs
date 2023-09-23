using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day08;

public class Year2017Day08 : AocPuzzle
{
    public override string Name => "I Heard You Like Registers";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new CpuInstructionCalculator(FileInput);
        return new PuzzleResult(calculator.LargestValueAtEnd, 6012);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new CpuInstructionCalculator(FileInput);
        return new PuzzleResult(calculator.LargestValueEver, 6369);
    }
}