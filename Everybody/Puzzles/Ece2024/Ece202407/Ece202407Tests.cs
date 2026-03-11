namespace Pzl.Everybody.Puzzles.Ece2024.Ece202407;

public class Ece202407Tests
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

    private static Ece202407 Sut => new();
}