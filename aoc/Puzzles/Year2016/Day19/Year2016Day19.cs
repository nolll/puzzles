using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day19;

public class Year2016Day19 : AocPuzzle
{
    public override string Name => "An Elephant Named Joseph";

    protected override PuzzleResult RunPart1()
    {
        var party = new WhiteElephantParty(Input);
        var winner = party.StealFromNextElf();
        return new PuzzleResult(winner, 1_808_357);
    }

    protected override PuzzleResult RunPart2()
    {
        var party = new WhiteElephantParty(Input);
        var winner = party.StealFromElfAcrossCircle();
        return new PuzzleResult(winner, 1_407_007);
    }

    private const int Input = 3001330;
}