namespace Pzl.Tools.Strings;

public class StringExtensionTests
{
    [Theory]
    [InlineData(1, "bcdefa")]
    [InlineData(2, "cdefab")]
    public void ShiftLeft(int steps, string expected) => 
        "abcdef".ShiftLeft(steps).Should().Be(expected);

    [Theory]
    [InlineData(1, "fabcde")]
    [InlineData(2, "efabcd")]
    public void ShiftRight(int steps, string expected) =>
        "abcdef".ShiftRight(steps).Should().Be(expected);

    [Theory]
    [InlineData(-2, "cdefab")]
    [InlineData(-1, "bcdefa")]
    [InlineData(0, "abcdef")]
    [InlineData(1, "fabcde")]
    [InlineData(2, "efabcd")]
    public void ShiftSteps(int steps, string expected) =>
        "abcdef".Shift(steps).Should().Be(expected);

    [Theory]
    [InlineData("abcde", false)]
    [InlineData("abcba", true)]
    public void ShiftString(string s, bool expected) =>
        s.IsPalindrome().Should().Be(expected);

    [Theory]
    [InlineData("ABCDE", true)]
    [InlineData("AbCdE", false)]
    [InlineData("abcde", false)]
    public void IsUpper(string s, bool expected) => 
        s.IsUpper().Should().Be(expected);

    [Theory]
    [InlineData("ABCDE", false)]
    [InlineData("AbCdE", false)]
    [InlineData("abcde", true)]
    public void IsLower(string s, bool expected) => 
        s.IsLower().Should().Be(expected);
}