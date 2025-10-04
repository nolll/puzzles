namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201510;

public class Aoc201510Tests
{
    [Theory]
    [InlineData("1", "11")]
    [InlineData("11", "21")]
    [InlineData("21", "1211")]
    [InlineData("1211", "111221")]
    [InlineData("111221", "312211")]
    public void CorrectSequence(string input, string expected)
    {
        var game = new LookAndSayGame(input, 1);

        game.Result.Should().Be(expected);
    }
}