using ConsoleApp.Puzzles.Year2017.Day21;
using Core.FractalArt;
using NUnit.Framework;

namespace Tests
{
    public class FractalArtTests
    {
        [Test]
        public void TwelvePixelsOnAfterTwoIterations()
        {
            const string input = @"
../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";

            var generator = new FractalArtGenerator(input);
            generator.Run(2);

            Assert.That(generator.PixelsOn, Is.EqualTo(12));
        }
    }
}