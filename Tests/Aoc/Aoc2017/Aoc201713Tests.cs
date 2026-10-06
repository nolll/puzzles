using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201713Tests : PuzzleTest<Aoc201713>
{
    private const string Input = """
                                 0: 3
                                 1: 2
                                 4: 4
                                 6: 4
                                 """;

    [Fact]
    public void SeverityIsCorrect() => Sut.Part1(Input).Should().Be(24);

    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(1, 0, false)]
    [InlineData(2, 0, true)]
    [InlineData(2, 1, false)]
    [InlineData(2, 2, true)]
    [InlineData(3, 2, false)]
    [InlineData(3, 3, false)]
    [InlineData(3, 4, true)]
    public void IsCaughtAfterIterations(int range, int iteration, bool expected)
    {
        var layer = new Aoc201713.FirewallLayer(range);
        var pos = layer.IsCaught(iteration);

        pos.Should().Be(expected);
    }

    [Fact]
    public void DelayUntilPassIsCorrect() => Sut.Part2(Input).Should().Be(10);
}