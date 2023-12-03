using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201704;

public class Aoc201704Tests
{
    [TestCase("aa bb cc dd ee", true)]
    [TestCase("aa bb cc dd aa", false)]
    [TestCase("aa bb cc dd aaa", true)]
    public void ValidatePassword1(string input, bool expected)
    {
        var validator = new PassphraseValidator();
        var coin = validator.IsValid1(input);

        coin.Should().Be(expected);
    }

    [TestCase("abcde fghij", true)]
    [TestCase("abcde xyz ecdab", false)]
    [TestCase("a ab abc abd abf abj", true)]
    [TestCase("iiii oiii ooii oooi oooo", true)]
    [TestCase("oiii ioii iioi iiio", false)]
    public void ValidatePassword2(string input, bool expected)
    {
        var validator = new PassphraseValidator();
        var coin = validator.IsValid2(input);

        coin.Should().Be(expected);
    }
}