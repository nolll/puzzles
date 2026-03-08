using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201706;

[Name("Memory Reallocation")]
public class Aoc201706 : AocPuzzle
{
    [Puzzle("5cc5e4c13f678b66cbe8e4c449049395")]
    public int Part1(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return reallocator.Steps;
    }

    [Puzzle("9db0fcedbdf5df5cc87a97b23d4e1414")]
    public int Part2(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return reallocator.LoopSize;
    }
}