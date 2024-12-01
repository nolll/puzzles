using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201619;

[Name("An Elephant Named Joseph")]
public class Aoc201619 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var party = new WhiteElephantParty(int.Parse(input));
        var winner = party.StealFromNextElf();
        return new PuzzleResult(winner, "0ff6e8f1eb200db98926c54e1a1fac6a");
    }

    public PuzzleResult RunPart2(string input)
    {
        var party = new WhiteElephantParty(int.Parse(input));
        var winner = party.StealFromElfAcrossCircle();
        return new PuzzleResult(winner, "b67fd31a59ecdb3e94d0fbdfc778e61f");
    }
}