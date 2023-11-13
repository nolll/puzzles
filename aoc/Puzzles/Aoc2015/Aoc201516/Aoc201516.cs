using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201516;

public class Aoc201516 : AocPuzzle
{
    public override string Name => "Aunt Sue";

    protected override PuzzleResult RunPart1()
    {
        var sueSelector = new SueSelector(InputFile);
        return new PuzzleResult(sueSelector.SueNumberPart1, "fc9e347f58cd62a8056800cedf1772ff");
    }

    protected override PuzzleResult RunPart2()
    {
        var sueSelector = new SueSelector(InputFile);
        return new PuzzleResult(sueSelector.SueNumberPart2, "d0cfc435d1459e83bcc2be3046271a1a");
    }
}