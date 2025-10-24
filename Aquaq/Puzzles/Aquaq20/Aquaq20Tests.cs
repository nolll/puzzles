namespace Pzl.Aquaq.Puzzles.Aquaq20;

public class Aquaq20Tests
{
    [Theory]
    [InlineData("3 A K 9 A 7 4 9", 1)]
    [InlineData("K Q 2 9 4 8 A A A K A 7", 2)]
    public void PlayBlackjack(string deck, int expected)
    {
        var result = Aquaq20.PlayBlackjack(deck);

        result.Should().Be(expected);
    }
}