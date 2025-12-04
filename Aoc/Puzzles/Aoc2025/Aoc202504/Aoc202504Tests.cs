namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202504;

public class Aoc202504Tests
{
    private const string Input = """
                                 ..@@.@@@@.
                                 @@@.@.@.@@
                                 @@@@@.@.@@
                                 @.@@@@..@.
                                 @@.@@@@.@@
                                 .@@@@@@@.@
                                 .@.@.@.@@@
                                 @.@@@.@@@@
                                 .@@@@@@@@.
                                 @.@.@@@.@.
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("13");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("43");

    private static Aoc202504 Sut => new();
}