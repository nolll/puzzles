namespace Pzl.Tools.Strings;

public class LevenshteinDistanceTests
{
    [Theory]
    [InlineData("abcde", "abcde", 0)]
    [InlineData("abcde", "abcdx", 1)]
    [InlineData("abcde", "abcxy", 2)]
    public void Difference(string a, string b, int expected) => 
        LevenshteinDistance.Compute(a, b).Should().Be(expected);
}