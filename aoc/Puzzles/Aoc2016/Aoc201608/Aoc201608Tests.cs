using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201608;

public class Aoc201608Tests
{
    [Test]
    public void PixelCount()
    {
        const string input = """
rect 3x2
rotate column x=1 by 1
rotate row y=0 by 4
rotate column x=1 by 1
""";

        var simulator = new ScreenSimulator(7, 3);
        var result = simulator.Run(input);

        result.PixelCount.Should().Be(6);
    }
}