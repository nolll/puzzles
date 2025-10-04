namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201514;

public class Aoc201514Tests
{
    [Fact]
    public void WinningReindeerDistance()
    {
        const string input = """
                             Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
                             Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
                             """;

        const int time = 1000;

        var race = new ReindeerRace(input.Trim(), time);

        race.WinningDistance.Should().Be(1120);
    }

    [Fact]
    public void WinningReindeerScore()
    {
        const string input = """
                             Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
                             Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
                             """;

        const int time = 1000;

        var race = new ReindeerRace(input.Trim(), time);

        race.WinningScore.Should().Be(689);
    }
}