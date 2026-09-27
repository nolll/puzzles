namespace Tests.Aoc.Aoc2015;

public class Aoc201504Tests
{
    [Theory]
    [InlineData("abcdef", 609043)]
    [InlineData("pqrstuv", 1048970)]
    public void CoinMined(string secretKey, int expected) => Sut.Part1(secretKey).Should().Be(expected);

    private static Pzl.Aoc.Puzzles.Aoc2015.Aoc201504.Aoc201504 Sut => new();
}