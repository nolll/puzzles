namespace Pzl.Aquaq.Puzzles.Aquaq33;

public class Aquaq33Tests
{
    [Fact]
    public void ThrowDarts()
    {
        var result = Aquaq33.Run(30);

        result.Should().Be(32);
    }

    [Theory]
    [InlineData(301, 6)]
    [InlineData(501, 9)]
    [InlineData(171, 3)]
    [InlineData(180, 3)]
    [InlineData(181, 4)]
    [InlineData(342, 6)]
    [InlineData(361, 7)]
    public void PlayOneGame(int target, int expected)
    {
        var dartGame = new DartGame();
        var result = dartGame.Play(target);

        result.Should().Be(expected);
    }
}