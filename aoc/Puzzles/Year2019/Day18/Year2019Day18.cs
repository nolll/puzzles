using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day18;

public class Year2019Day18 : AocPuzzle
{
    public override string Name => "Many-Worlds Interpretation";
    public override string Comment => "Key Collector - Part 2 is too optimized. Tests fails";
    public override bool NeedsRewrite => true;

    protected override PuzzleResult RunPart1()
    {
        var keyCollector = new KeyCollector(FileInput);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, 4420);
    }

    protected override PuzzleResult RunPart2()
    {
        var keyCollector = new KeyCollector(FileInput, true);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, 2128);
    }
}