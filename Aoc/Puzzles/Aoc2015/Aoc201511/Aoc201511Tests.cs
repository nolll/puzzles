using FluentAssertions;
using NUnit.Framework;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

public class Aoc201511Tests
{
    [TestCase("hijklmmn", false)]
    [TestCase("abbceffg", false)]
    [TestCase("abbcegjk", false)]
    [TestCase("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected) => 
        CorporatePasswordValidator.IsValid(pwd).Should().Be(expected);

    [TestCase("abcdefgh", "abcdffaa")]
    [TestCase("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected) => Sut.Part1(pwd).Answer.Should().Be(expected);

    private static Aoc201511 Sut => new();
}