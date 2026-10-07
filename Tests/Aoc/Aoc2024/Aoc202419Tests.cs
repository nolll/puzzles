using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202419Tests : PuzzleTest<Aoc202419>
{
    private const string Input = """
                                 r, wr, b, g, bwu, rb, gb, br

                                 brwrr
                                 bggr
                                 gbbr
                                 rrbgbr
                                 ubwu
                                 bwurrg
                                 brgr
                                 bbrgwb
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(6);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(16);

}