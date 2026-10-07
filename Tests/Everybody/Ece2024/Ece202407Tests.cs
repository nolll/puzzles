using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202407Tests : PuzzleTest<Ece202407>
{
    private const string Input = """
                                 A:+,-,=,=
                                 B:+,=,-,+
                                 C:=,-,+,+
                                 D:=,=,=,+
                                 """;

    private const string Track = """
                                 S+===
                                 -   +
                                 =+=-+
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be("BDCA");

    [Fact]
    public void Part2() => Sut.SolvePart2(Track, Input).Should().Be("DCBA");

}