using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202017Tests : PuzzleTest<Aoc202017>
{
    private const string Input = """
                                 .#.
                                 ..#
                                 ###
                                 """;

    [Fact]
    public void AfterSixIterations_3D() => Sut.Part1(Input).Should().Be(112);

    [Fact]
    public void AfterSixIterations_4D() => Sut.Part2(Input).Should().Be(848);
}