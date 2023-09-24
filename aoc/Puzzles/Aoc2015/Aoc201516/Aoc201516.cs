using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201516;

public class Aoc201516 : AocPuzzle
{
    public override string Name => "Aunt Sue";

    protected override PuzzleResult RunPart1()
    {
        var sueSelector = new SueSelector(InputFile);
        return new PuzzleResult(sueSelector.SueNumberPart1, 373);
    }

    protected override PuzzleResult RunPart2()
    {
        var sueSelector = new SueSelector(InputFile);
        return new PuzzleResult(sueSelector.SueNumberPart2, 260);
    }
}