using FluentAssertions;
using NUnit.Framework;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201504;

public class Aoc201504Tests
{
    [TestCase("abcdef", "609043")]
    [TestCase("pqrstuv", "1048970")]
    public void CoinMined(string secretKey, string expected) => Sut.Part1(secretKey).Answer.Should().Be(expected);

    private static Aoc201504 Sut => new();
}