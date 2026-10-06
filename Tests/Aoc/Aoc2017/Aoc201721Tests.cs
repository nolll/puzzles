using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201721Tests : PuzzleTest<Aoc201721>
{
    private const string Input = """
                                 ../.# => ##./#../...
                                 .#./..#/### => #..#/..../..../#..#
                                 """;

    [Fact]
    public void TwelvePixelsOnAfterTwoIterations() => Sut.Run(Input, 2).Should().Be(12);
}