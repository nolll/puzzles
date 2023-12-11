using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201619;

[Name("An Elephant Named Joseph")]
public class Aoc201619(string input) : AocPuzzle(input)
{
    private int IntInput => int.Parse(Input);

    protected override PuzzleResult RunPart1()
    {
        var party = new WhiteElephantParty(IntInput);
        var winner = party.StealFromNextElf();
        return new PuzzleResult(winner, "0ff6e8f1eb200db98926c54e1a1fac6a");
    }

    protected override PuzzleResult RunPart2()
    {
        var party = new WhiteElephantParty(IntInput);
        var winner = party.StealFromElfAcrossCircle();
        return new PuzzleResult(winner, "b67fd31a59ecdb3e94d0fbdfc778e61f");
    }
}