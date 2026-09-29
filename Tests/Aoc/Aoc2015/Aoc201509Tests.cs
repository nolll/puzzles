using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201509Tests
{
    private const string Input = """
                                 London to Dublin = 464
                                 London to Belfast = 518
                                 Dublin to Belfast = 141
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(605);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(982);

    private static Aoc201509 Sut => new();
}