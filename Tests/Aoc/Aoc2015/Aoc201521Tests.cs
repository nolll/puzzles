using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201521Tests : PuzzleTest<Aoc201521>
{
    [Fact]
    public void PlayerWinsInFourRounds()
    {
        var winner = Sut.Run(12, 7, 2, 8, 5, 5);
        
        winner.Type.Should().Be(Aoc201521.RpgCharacterType.Player);
        winner.Points.Should().Be(2);
    }
}