using NUnit.Framework;

namespace Aoc.Puzzles.Year2015.Day14;

public class Year2015Day14Tests
{
    [Test]
    public void WinningReindeerDistance()
    {
        const string input = """
Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
""";

        const int time = 1000;

        var race = new ReindeerRace(input.Trim(), time);

        Assert.That(race.WinningDistance, Is.EqualTo(1120));
    }

    [Test]
    public void WinningReindeerScore()
    {
        const string input = """
Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
""";

        const int time = 1000;

        var race = new ReindeerRace(input.Trim(), time);

        Assert.That(race.WinningScore, Is.EqualTo(689));
    }
}