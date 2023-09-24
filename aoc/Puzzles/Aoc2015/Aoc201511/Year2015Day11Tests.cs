using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201511;

public class Year2015Day11Tests
{
    [TestCase("hijklmmn", false)]
    [TestCase("abbceffg", false)]
    [TestCase("abbcegjk", false)]
    [TestCase("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected)
    {
        var validator = new CorporatePasswordValidator();
        var isValid = validator.IsValid(pwd);

        Assert.That(isValid, Is.EqualTo(expected));
    }

    [TestCase("abcdefgh", "abcdffaa")]
    [TestCase("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected)
    {
        var validator = new CorporatePasswordValidator();
        var next = validator.FindNextPassword(pwd);

        Assert.That(next, Is.EqualTo(expected));
    }
}