using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq14;

public class Aquaq14Tests
{
    [TestCase("10 5 21 45 53 70 66 4", 7)]
    [TestCase("400 500 17 21 25 30 23 600 700", 7)]
    [TestCase("400 500 6 21 36 54 62 600 700", 7)]
    [TestCase("400 500 15 30 36 53 68 600 700", 7)]
    public void Bingo(string input, int expected)
    {
        var result = Aquaq14.PlayBingo(input);

        result.Should().Be(expected);
    }
}