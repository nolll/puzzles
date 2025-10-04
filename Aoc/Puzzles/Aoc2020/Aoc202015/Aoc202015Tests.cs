namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202015;

public class Aoc202015Tests
{
    [Theory]
    [InlineData("0,3,6", 2020, 436)]
    [InlineData("1,3,2", 2020, 1)]
    [InlineData("2,1,3", 2020, 10)]
    [InlineData("1,2,3", 2020, 27)]
    [InlineData("2,3,1", 2020, 78)]
    [InlineData("3,2,1", 2020, 438)]
    [InlineData("3,1,2", 2020, 1836)]
    [InlineData("0,3,6", 30000000, 175594)]
    [InlineData("1,3,2", 30000000, 2578)]
    [InlineData("2,1,3", 30000000, 3544142)]
    [InlineData("1,2,3", 30000000, 261214)]
    [InlineData("2,3,1", 30000000, 6895259)]
    [InlineData("3,2,1", 30000000, 18)]
    [InlineData("3,1,2", 30000000, 362)]
    public void Find2020ThNumber(string input, int until, long expected)
    {
        var numbers = new MemoryGame(input);
        var result = numbers.Play(until);

        result.Should().Be(expected);
    }
}