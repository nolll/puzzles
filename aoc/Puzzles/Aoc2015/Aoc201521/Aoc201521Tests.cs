using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201521;

public class Aoc201521Tests
{
    [Test]
    public void PlayerWinsInFourRounds()
    {
        var simulator = new RpgSimulator();
        var winner = simulator.Run(12, 7, 2, 8, 5, 5);

        Assert.That(simulator.RoundsPlayed, Is.EqualTo(4));
        Assert.That(winner.Name, Is.EqualTo("player"));
        Assert.That(winner.Points, Is.EqualTo(2));
    }
}