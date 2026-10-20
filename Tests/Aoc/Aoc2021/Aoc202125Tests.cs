using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202125Tests : PuzzleTest<Aoc202125>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(58);

    private const string Input = """
                                 v...>>.vv>
                                 .vv>>.vv..
                                 >>.>v>...v
                                 >>v>>.>.v.
                                 v>v.vv.v..
                                 >.>>..v...
                                 .vv..>.>v.
                                 v.v..>>v.v
                                 ....v..v.>
                                 """;
}