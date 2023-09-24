using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Day21;

public class Year2017Day21Tests
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

        Assert.That(generator.PixelsOn, Is.EqualTo(12));
    }
}