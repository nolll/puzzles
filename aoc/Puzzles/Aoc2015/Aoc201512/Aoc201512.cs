using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201512;

public class Aoc201512 : AocPuzzle
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