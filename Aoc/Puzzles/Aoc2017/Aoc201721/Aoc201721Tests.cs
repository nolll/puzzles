using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

public class Aoc201721Tests
{
    [Test]
    public void TwelvePixelsOnAfterTwoIterations()
    {
        const string input = """
                             ../.# => ##./#../...
                             .#./..#/### => #..#/..../..../#..#
                             """;

        var generator = new FractalArtGenerator(input.Trim());
        generator.Run(2);

        generator.PixelsOn.Should().Be(12);
    }
}