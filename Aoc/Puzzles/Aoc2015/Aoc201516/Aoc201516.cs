using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

[Name("Aunt Sue")]
public class Aoc201516 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var sueSelector = new SueSelector(input);
        return new PuzzleResult(sueSelector.SueNumberPart1, "fc9e347f58cd62a8056800cedf1772ff");
    }

    public PuzzleResult RunPart2(string input)
    {
        var sueSelector = new SueSelector(input);
        return new PuzzleResult(sueSelector.SueNumberPart2, "d0cfc435d1459e83bcc2be3046271a1a");
    }
}