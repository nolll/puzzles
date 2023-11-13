using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aquaq.Puzzles.Aquaq18;

public class Aquaq18Tests
{
    [TestCase("13:41:00", false)]
    [TestCase("13:44:31", true)]
    public void IsPalindrome(string input, bool expected)
    {
        var dateTime = DateTime.Parse($"2020-02-02 {input}");
        var result = Aquaq18.IsPalindromeTime(dateTime);

        result.Should().Be(expected);
    }

    [Test]
    public void StepsToPalindrome()
    {
        var dateTime = DateTime.Parse("2020-02-02 13:41:00");
        var result = Aquaq18.StepsToPalindrome(dateTime);

        result.Should().Be(211);
    }
}