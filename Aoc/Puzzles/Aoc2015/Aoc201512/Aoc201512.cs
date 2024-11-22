using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201512;

[Name("JSAbacusFramework.io")]
public class Aoc201512(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var doc = new JsonDoc(input, true);
        return new PuzzleResult(doc.Sum, "72e4a93f95510bb5f9d0b20360676111");
    }

    protected override PuzzleResult RunPart2()
    {
        var doc = new JsonDoc(input, false);
        return new PuzzleResult(doc.Sum, "c5934cc2e7d3cc9b1183329d8d2f1d82");
    }
}