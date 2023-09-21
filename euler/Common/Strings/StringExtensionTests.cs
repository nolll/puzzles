using NUnit.Framework;

namespace Euler.Common.Strings;

public class StringExtensionTests
{
    [TestCase(1, "bcdefa")]
    [TestCase(2, "cdefab")]
    public void ShiftLeft(int steps, string expected)
    {
        const string s = "abcdef";
        var result = s.ShiftLeft(steps);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, "fabcde")]
    [TestCase(2, "efabcd")]
    public void ShiftRight(int steps, string expected)
    {
        const string s = "abcdef";
        var result = s.ShiftRight(steps);

        Assert.That(result, Is.EqualTo(expected));
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

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("abcde", false)]
    [TestCase("abcba", true)]
    public void Shift(string s, bool expected)
    {
        var result = s.IsPalindrome();

        Assert.That(result, Is.EqualTo(expected));
    }
}