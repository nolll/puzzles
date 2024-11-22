using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

public class Aoc201511Tests
{
    [TestCase("hijklmmn", false)]
    [TestCase("abbceffg", false)]
    [TestCase("abbcegjk", false)]
    [TestCase("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected)
    {
        var validator = new CorporatePasswordValidator();
        var isValid = validator.IsValid(pwd);

        isValid.Should().Be(expected);
    }

    [TestCase("abcdefgh", "abcdffaa")]
    [TestCase("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected)
    {
        var validator = new CorporatePasswordValidator();
        var next = validator.FindNextPassword(pwd);

        next.Should().Be(expected);
    }
}