using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201706;

public class Aoc201706 : AocPuzzle
{
    public override string Name => "Memory Reallocation";

    protected override PuzzleResult RunPart1()
    {
        var reallocator = new MemoryReallocator(InputFile);
        reallocator.Run();
        return new PuzzleResult(reallocator.Steps, "5cc5e4c13f678b66cbe8e4c449049395");
    }

    protected override PuzzleResult RunPart2()
    {
        var reallocator = new MemoryReallocator(InputFile);
        reallocator.Run();
        return new PuzzleResult(reallocator.LoopSize, "9db0fcedbdf5df5cc87a97b23d4e1414");
    }
}