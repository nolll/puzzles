using NUnit.Framework;

namespace Core.Puzzles.Year2015.Day21;

public class Year2015Day21Tests
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