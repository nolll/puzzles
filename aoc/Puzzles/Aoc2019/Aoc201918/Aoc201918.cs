using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201918;

public class Aoc201918 : AocPuzzle
{
    public override string Name => "Many-Worlds Interpretation";
    public override string Comment => "Key Collector - Part 2 is too optimized. Tests fails";
    public override bool NeedsRewrite => true;

    protected override PuzzleResult RunPart1()
    {
        var keyCollector = new KeyCollector(InputFile);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, 4420);
    }

    protected override PuzzleResult RunPart2()
    {
        var keyCollector = new KeyCollector(InputFile, true);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, 2128);
    }
}