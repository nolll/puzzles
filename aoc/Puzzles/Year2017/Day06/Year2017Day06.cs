using Common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day06;

public class Year2017Day06 : AocPuzzle
{
    public override string Name => "Memory Reallocation";

    protected override PuzzleResult RunPart1()
    {
        var reallocator = new MemoryReallocator(FileInput);
        reallocator.Run();
        return new PuzzleResult(reallocator.Steps, 6681);
    }

    protected override PuzzleResult RunPart2()
    {
        var reallocator = new MemoryReallocator(FileInput);
        reallocator.Run();
        return new PuzzleResult(reallocator.LoopSize, 2392);
    }
}