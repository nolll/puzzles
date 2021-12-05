using ConsoleApp.Puzzles.Year2018.Puzzles.Day17;
using NUnit.Framework;

namespace Tests
{
    public class ReservoirResearchTests
    {
        [Test]
        public void NumberOfWaterTilesIsCorrect()
        {
            const string input = @"
x=495, y=2..7
y=7, x=495..501
x=501, y=3..7
x=498, y=2..4
x=506, y=1..2
x=498, y=10..13
x=504, y=10..13
y=13, x=498..504";

            var filler = new ReservoirFiller(input);
            filler.Fill();

            Assert.That(filler.TotalWaterTileCount, Is.EqualTo(57));
            Assert.That(filler.RetainedWaterTileCount, Is.EqualTo(29));
        }
    }
}