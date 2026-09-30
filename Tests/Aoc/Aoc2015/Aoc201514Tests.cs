using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201514Tests
{
    private const int Time = 1000;

    private const string Input = """
                                 Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
                                 Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
                                 """;

    [Fact]
    public void WinningReindeerDistance() => Sut.GetWinningDistance(Input, Time).Should().Be(1120);

    [Fact]
    public void WinningReindeerScore() => Sut.GetWinningScore(Input, Time).Should().Be(689);

    private static Aoc201514 Sut => new();
}