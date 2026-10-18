using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202103Tests : PuzzleTest<Aoc202103>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(198);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(230);

    private const string Input = """
                                 00100
                                 11110
                                 10110
                                 10111
                                 10101
                                 01111
                                 00111
                                 11100
                                 10000
                                 11001
                                 00010
                                 01010
                                 """;
}