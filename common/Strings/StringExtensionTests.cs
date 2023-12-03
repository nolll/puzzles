using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.common.Strings;

public class StringExtensionTests
{
    [TestCase(1, "bcdefa")]
    [TestCase(2, "cdefab")]
    public void ShiftLeft(int steps, string expected)
    {
        const string s = "abcdef";
        var result = s.ShiftLeft(steps);

        result.Should().Be(expected);
    }

    [TestCase(1, "fabcde")]
    [TestCase(2, "efabcd")]
    public void ShiftRight(int steps, string expected)
    {
        const string s = "abcdef";
        var result = s.ShiftRight(steps);

        result.Should().Be(expected);
    }

    [TestCase(-2, "cdefab")]
    [TestCase(-1, "bcdefa")]
    [TestCase(0, "abcdef")]
    [TestCase(1, "fabcde")]
    [TestCase(2, "efabcd")]
    public void Shift(int steps, string expected)
    {
        const string s = "abcdef";
        var result = s.Shift(steps);

        result.Should().Be(expected);
    }

    [TestCase("abcde", false)]
    [TestCase("abcba", true)]
    public void Shift(string s, bool expected)
    {
        var result = s.IsPalindrome();

        result.Should().Be(expected);
    }

    [TestCase("ABCDE", true)]
    [TestCase("AbCdE", false)]
    [TestCase("abcde", false)]
    public void IsUpper(string s, bool expected)
    {
        var result = s.IsUpper();

        result.Should().Be(expected);
    }

    [TestCase("ABCDE", false)]
    [TestCase("AbCdE", false)]
    [TestCase("abcde", true)]
    public void IsLower(string s, bool expected)
    {
        var result = s.IsLower();

        result.Should().Be(expected);
    }
}