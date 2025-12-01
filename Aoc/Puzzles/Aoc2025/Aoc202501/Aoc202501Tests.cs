namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202501;

public class Aoc202501Tests
{
    private const string Input = """
                                 L68
                                 L30
                                 R48
                                 L5
                                 R60
                                 L55
                                 L1
                                 L99
                                 R14
                                 L82
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("3");

    [Theory]
    [InlineData(0, 6)]
    [InlineData(1, 16)]
    [InlineData(10, 106)]
    public void Part2(int extraOrbits, int expected) => Sut.Part2(Input, extraOrbits).Should().Be(expected);

    private static Aoc202501 Sut => new();
}