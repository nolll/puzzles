using Aoc.Platform;

namespace Aoc.Puzzles.Year2017.Day06;

public class Year2017Day06 : Puzzle
{
    public override string Title => "Memory Reallocation";

    public override PuzzleResult RunPart1()
    {
        var reallocator = new MemoryReallocator(FileInput);
        reallocator.Run();
        return new PuzzleResult(reallocator.Steps, 6681);
    }

    public override PuzzleResult RunPart2()
    {
        var reallocator = new MemoryReallocator(FileInput);
        reallocator.Run();
        return new PuzzleResult(reallocator.LoopSize, 2392);
    }
}