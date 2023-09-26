using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201706;

public class Aoc201706 : AocPuzzle
{
    public override string Name => "Memory Reallocation";

    protected override PuzzleResult RunPart1()
    {
        var reallocator = new MemoryReallocator(InputFile);
        reallocator.Run();
        return new PuzzleResult(reallocator.Steps, 6681);
    }

    protected override PuzzleResult RunPart2()
    {
        var reallocator = new MemoryReallocator(InputFile);
        reallocator.Run();
        return new PuzzleResult(reallocator.LoopSize, 2392);
    }
}