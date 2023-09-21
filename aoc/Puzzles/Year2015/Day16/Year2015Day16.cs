using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day16;

public class Year2015Day16 : AocPuzzle
{
    public override string Name => "Aunt Sue";

    public override PuzzleResult RunPart1()
    {
        var sueSelector = new SueSelector(FileInput);
        return new PuzzleResult(sueSelector.SueNumberPart1, 373);
    }

    public override PuzzleResult RunPart2()
    {
        var sueSelector = new SueSelector(FileInput);
        return new PuzzleResult(sueSelector.SueNumberPart2, 260);
    }
}