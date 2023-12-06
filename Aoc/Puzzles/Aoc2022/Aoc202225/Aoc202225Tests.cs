using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202225;

public class Aoc202225Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new Aoc202225();
        var result = puzzle.Part1(Input);

        result.Should().Be("2=-1=0");
    }
    
    [TestCase("1=-0-2", 1747)]
    [TestCase("12111", 906)]
    [TestCase("2=0=", 198)]
    [TestCase("21", 11)]
    [TestCase("2=01", 201)]
    [TestCase("111", 31)]
    [TestCase("20012", 1257)]
    [TestCase("112", 32)]
    [TestCase("1=-1=", 353)]
    [TestCase("1-12", 107)]
    [TestCase("12", 7)]
    [TestCase("1=", 3)]
    [TestCase("122", 37)]
    public void ToDecimal(string input, int expected)
    {
        var result = SnafuConverter.ToNumber(input);

        result.Should().Be(expected);
    }

    [TestCase(1747, "1=-0-2")]
    [TestCase(906, "12111")]
    [TestCase(198, "2=0=")]
    [TestCase(11, "21")]
    [TestCase(201, "2=01")]
    [TestCase(31, "111")]
    [TestCase(1257, "20012")]
    [TestCase(32, "112")]
    [TestCase(353, "1=-1=")]
    [TestCase(107, "1-12")]
    [TestCase(7, "12")]
    [TestCase(3, "1=")]
    [TestCase(37, "122")]
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