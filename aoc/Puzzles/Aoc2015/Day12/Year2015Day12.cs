using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day12;

public class Year2015Day12 : AocPuzzle
{
    public override string Name => "JSAbacusFramework.io";

    protected override PuzzleResult RunPart1()
    {
        var doc = new JsonDoc(InputFile, true);
        return new PuzzleResult(doc.Sum, 119_433);
    }

    protected override PuzzleResult RunPart2()
    {
        var doc = new JsonDoc(InputFile, false);
        return new PuzzleResult(doc.Sum, 68_466);
    }
}