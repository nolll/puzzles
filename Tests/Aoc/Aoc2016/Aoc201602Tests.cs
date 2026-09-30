using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201602Tests : PuzzleTest<Aoc201602>
{
    private const string Input = """
                                 ULL
                                 RRDDD
                                 LURDL
                                 UUUUD
                                 """;

    [Fact]
    public void FindsSquareKeycode() => Sut.FindPart1Code(Input).Should().Be("1985");

    [Fact]
    public void FindsDiamondKeycode() => Sut.FindPart2Code(Input).Should().Be("5DB3");
}