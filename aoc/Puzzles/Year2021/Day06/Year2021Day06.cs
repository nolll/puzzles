using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day06;

public class Year2021Day06 : AocPuzzle
{
    public override string Name => "Lanternfish";

    protected override PuzzleResult RunPart1()
    {
        var fishCounter = new FishCounter(FileInput);
        var result = fishCounter.FishCountAfter(80);
        return new PuzzleResult(result, 383_160);
    }

    protected override PuzzleResult RunPart2()
    {
        var fishCounter = new FishCounter(FileInput);
        var result = fishCounter.FishCountAfter(256);
        return new PuzzleResult(result, 1_721_148_811_504);
    }
}