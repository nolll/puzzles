using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day03;

public class Year2017Day03 : AocPuzzle
{
    public override string Name => "Spiral Memory";

    protected override PuzzleResult RunPart1()
    {
        var memory1 = new SpiralMemory(Input, SpiralMemoryMode.RunToTarget);
        return new PuzzleResult(memory1.Distance, 438);
    }

    protected override PuzzleResult RunPart2()
    {
        var memory2 = new SpiralMemory(Input, SpiralMemoryMode.RunToValue);
        return new PuzzleResult(memory2.Value, 266_330);
    }

    private const int Input = 265149;
}