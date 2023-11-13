using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201521;

public class Aoc201521Tests
{
    [Test]
    public void PlayerWinsInFourRounds()
    {
        var simulator = new RpgSimulator();
        var winner = simulator.Run(12, 7, 2, 8, 5, 5);

        simulator.RoundsPlayed.Should().Be(4);
        winner.Name.Should().Be("player");
        winner.Points.Should().Be(2);
    }
}