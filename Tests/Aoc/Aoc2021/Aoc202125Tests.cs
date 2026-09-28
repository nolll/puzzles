using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202125Tests
{
    [Fact]
    public void Part1()
    {
        var herd = new Aoc202125.HerdOfSeaCucumbers(Input);
        var result = herd.MoveUntilStop();

        result.Should().Be(58);
    }

    [Fact]
    public void Part2()
    {
        var result = 0;

        result.Should().Be(0);
    }

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