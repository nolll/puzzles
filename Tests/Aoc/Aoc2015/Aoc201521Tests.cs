using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201521Tests : PuzzleTest<Aoc201521>
{
    [Fact]
    public void PlayerWinsInFourRounds()
    {
        var simulator = new Aoc201521.RpgSimulator();
        var winner = simulator.Run(12, 7, 2, 8, 5, 5);

        simulator.RoundsPlayed.Should().Be(4);
        winner.Name.Should().Be("player");
        winner.Points.Should().Be(2);
    }
}