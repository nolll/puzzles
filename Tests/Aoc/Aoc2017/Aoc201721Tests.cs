using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201721Tests : PuzzleTest<Aoc201721>
{
    [Fact]
    public void TwelvePixelsOnAfterTwoIterations()
    {
        const string input = """
                             ../.# => ##./#../...
                             .#./..#/### => #..#/..../..../#..#
                             """;

        var generator = new Aoc201721.FractalArtGenerator(input.Trim());
        generator.Run(2);

        generator.PixelsOn.Should().Be(12);
    }
}