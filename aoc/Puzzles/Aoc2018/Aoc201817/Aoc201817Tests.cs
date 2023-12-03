using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201817;

public class Aoc201817Tests
{
    [Test]
    public void NumberOfWaterTilesIsCorrect()
    {
        const string input = """
x=495, y=2..7
y=7, x=495..501
x=501, y=3..7
x=498, y=2..4
x=506, y=1..2
x=498, y=10..13
x=504, y=10..13
y=13, x=498..504
""";

        var filler = new ReservoirFiller(input.Trim());
        filler.Fill();

        filler.TotalWaterTileCount.Should().Be(57);
        filler.RetainedWaterTileCount.Should().Be(29);
    }
}