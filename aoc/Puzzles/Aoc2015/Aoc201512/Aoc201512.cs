using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201512;

public class Aoc201512 : AocPuzzle
{
    public override string Name => "JSAbacusFramework.io";

    protected override PuzzleResult RunPart1()
    {
        var doc = new JsonDoc(InputFile, true);
        return new PuzzleResult(doc.Sum, "72e4a93f95510bb5f9d0b20360676111");
    }

    protected override PuzzleResult RunPart2()
    {
        var doc = new JsonDoc(InputFile, false);
        return new PuzzleResult(doc.Sum, "c5934cc2e7d3cc9b1183329d8d2f1d82");
    }
}