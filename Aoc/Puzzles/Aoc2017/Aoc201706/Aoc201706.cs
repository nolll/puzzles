using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201706;

[Name("Memory Reallocation")]
public class Aoc201706 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return new PuzzleResult(reallocator.Steps, "5cc5e4c13f678b66cbe8e4c449049395");
    }

    public PuzzleResult RunPart2(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return new PuzzleResult(reallocator.LoopSize, "9db0fcedbdf5df5cc87a97b23d4e1414");
    }
}