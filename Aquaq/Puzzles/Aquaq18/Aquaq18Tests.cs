namespace Pzl.Aquaq.Puzzles.Aquaq18;

public class Aquaq18Tests
{
    [Theory]
    [InlineData("13:41:00", false)]
    [InlineData("13:44:31", true)]
    public void IsPalindrome(string input, bool expected)
    {
        var dateTime = DateTime.Parse($"2020-02-02 {input}");
        var result = Aquaq18.IsPalindromeTime(dateTime);

        result.Should().Be(expected);
    }

    [Fact]
    public void StepsToPalindrome()
    {
        var dateTime = DateTime.Parse("2020-02-02 13:41:00");
        var result = Aquaq18.StepsToPalindrome(dateTime);

        result.Should().Be(211);
    }
}