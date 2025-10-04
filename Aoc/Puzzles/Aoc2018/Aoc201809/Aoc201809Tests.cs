namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201809;

public class Aoc201809Tests
{
    [Theory]
    [InlineData(10, 1618, 8317)]
    [InlineData(13, 7999, 146373)]
    [InlineData(17, 1104, 2764)]
    [InlineData(21, 6111, 54718)]
    [InlineData(30, 5807, 37305)]
    public void WinnerScoreIsCorrect(int playerCount, int lastMarbleValue, int expectedScore)
    {
        var game = new MarbleGame(playerCount, lastMarbleValue);

        game.WinnerScore.Should().Be(expectedScore);
    }
}