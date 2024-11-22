using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Strings;

public class StringExtensionTests
{
    [TestCase(1, "bcdefa")]
    [TestCase(2, "cdefab")]
    public void ShiftLeft(int steps, string expected) => 
        "abcdef".ShiftLeft(steps).Should().Be(expected);

    [TestCase(1, "fabcde")]
    [TestCase(2, "efabcd")]
    public void ShiftRight(int steps, string expected) =>
        "abcdef".ShiftRight(steps).Should().Be(expected);

    [TestCase(-2, "cdefab")]
    [TestCase(-1, "bcdefa")]
    [TestCase(0, "abcdef")]
    [TestCase(1, "fabcde")]
    [TestCase(2, "efabcd")]
    public void Shift(int steps, string expected) =>
        "abcdef".Shift(steps).Should().Be(expected);

    [TestCase("abcde", false)]
    [TestCase("abcba", true)]
    public void Shift(string s, bool expected) =>
        s.IsPalindrome().Should().Be(expected);

    [TestCase("ABCDE", true)]
    [TestCase("AbCdE", false)]
    [TestCase("abcde", false)]
    public void IsUpper(string s, bool expected) => 
        s.IsUpper().Should().Be(expected);

    [TestCase("ABCDE", false)]
    [TestCase("AbCdE", false)]
    [TestCase("abcde", true)]
    public void IsLower(string s, bool expected) => 
        s.IsLower().Should().Be(expected);
}