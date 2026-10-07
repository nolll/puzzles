using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201615Tests : PuzzleTest<Aoc201615>
{
    [Theory]
    [InlineData(5, 4, 0, false)]
    [InlineData(5, 4, 1, true)]
    [InlineData(5, 4, 2, false)]
    [InlineData(2, 1, 0, false)]
    [InlineData(2, 1, 1, true)]
    public void CapsulePassesDisc(int positions, int startPos, int time, bool expected)
    {
        var disc = new Aoc201615.KineticSculptureDisc(positions, startPos);
        var pos = disc.Passed(time);

        pos.Should().Be(expected);
    }

    [Fact]
    public void CapsulePassesAtTime5()
    {
        const string input = """
                             Disc #1 has 5 positions; at time=0, it is at position 4.
                             Disc #2 has 2 positions; at time=0, it is at position 1.
                             """;

        Sut.Part1(input).Should().Be(5);
    }
}