using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day12;

public class Year2015Day12 : AocPuzzle
{
    public override string Title => "JSAbacusFramework.io";

    public override PuzzleResult RunPart1()
    {
        var doc = new JsonDoc(FileInput, true);
        return new PuzzleResult(doc.Sum, 119_433);
    }

    public override PuzzleResult RunPart2()
    {
        var doc = new JsonDoc(FileInput, false);
        return new PuzzleResult(doc.Sum, 68_466);
    }
}