using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq18Tests : PuzzleTest<Aquaq18>
{
    [Theory]
    [InlineData("13:41:00", false)]
    [InlineData("13:44:31", true)]
    public void IsPalindrome(string input, bool expected) => Aquaq18.IsPalindromeTime(DateTime.Parse($"2020-02-02 {input}")).Should().Be(expected);

    [Fact]
    public void StepsToPalindrome() => Aquaq18.StepsToPalindrome(DateTime.Parse("2020-02-02 13:41:00")).Should().Be(211);
}