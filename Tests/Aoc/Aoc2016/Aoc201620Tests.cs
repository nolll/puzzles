using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201620Tests : PuzzleTest<Aoc201620>
{
    private const string Input = """
                                 5-8
                                 0-2
                                 4-7
                                 """;

    [Fact]
    public void FindsUnblockedIps() => Sut.GetLowestUnblockedIp(Input).Should().Be(3);

    [Fact]
    public void AllowedIpCountIsCorrect() => Sut.GetAllowedIpCount(Input, 9).Should().Be(2);
}