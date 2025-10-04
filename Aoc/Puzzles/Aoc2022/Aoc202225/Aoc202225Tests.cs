namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202225;

public class Aoc202225Tests
{
    [Fact]
    public void Part1()
    {
        var puzzle = new Aoc202225();
        var result = puzzle.Part1(Input);

        result.Should().Be("2=-1=0");
    }
    
    [Theory]
    [InlineData("1=-0-2", 1747)]
    [InlineData("12111", 906)]
    [InlineData("2=0=", 198)]
    [InlineData("21", 11)]
    [InlineData("2=01", 201)]
    [InlineData("111", 31)]
    [InlineData("20012", 1257)]
    [InlineData("112", 32)]
    [InlineData("1=-1=", 353)]
    [InlineData("1-12", 107)]
    [InlineData("12", 7)]
    [InlineData("1=", 3)]
    [InlineData("122", 37)]
    public void ToDecimal(string input, int expected)
    {
        var result = SnafuConverter.ToNumber(input);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1747, "1=-0-2")]
    [InlineData(906, "12111")]
    [InlineData(198, "2=0=")]
    [InlineData(11, "21")]
    [InlineData(201, "2=01")]
    [InlineData(31, "111")]
    [InlineData(1257, "20012")]
    [InlineData(32, "112")]
    [InlineData(353, "1=-1=")]
    [InlineData(107, "1-12")]
    [InlineData(7, "12")]
    [InlineData(3, "1=")]
    [InlineData(37, "122")]
    public void ToSnafu(int input, string expected)
    {
        var result = SnafuConverter.ToSnafu(input);

        result.Should().Be(expected);
    }

    private const string Input = """
                                 1=-0-2
                                 12111
                                 2=0=
                                 21
                                 2=01
                                 111
                                 20012
                                 112
                                 1=-1=
                                 1-12
                                 12
                                 1=
                                 122
                                 """;
}