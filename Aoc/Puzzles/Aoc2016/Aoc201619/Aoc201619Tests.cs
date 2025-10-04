namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201619;

public class Aoc201619Tests
{
    [Fact]
    public void StealFromNextElf_ThirdElfGetsAllPresents()
    {
        const int input = 5;

        var party = new WhiteElephantParty(input);
        var winner = party.StealFromNextElf();

        winner.Should().Be(3);
    }

    [Fact]
    public void StealFromAcrossTheCircle_SecondElfGetsAllPresents()
    {
        const int input = 5;

        var party = new WhiteElephantParty(input);
        var winner = party.StealFromElfAcrossCircle();

        winner.Should().Be(2);
    }
}