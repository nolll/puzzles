using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201619;

public class Aoc201619 : AocPuzzle
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