using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.common.Strings;

public class LevenshteinDistanceTests
{
    [Test]
    public void NoDifference()
    {
        const string str = "abcde";
        var distance = LevenshteinDistance.Compute(str, str);
        distance.Should().Be(0);
    }

    [Test]
    public void OneCharDifference()
    {
        const string str1 = "abcde";
        const string str2 = "abcdX";
        var distance = LevenshteinDistance.Compute(str1, str2);
        distance.Should().Be(1);
    }

    [Test]
    public void TwoCharDifference()
    {
        const string str1 = "abcde";
        const string str2 = "abcXY";
        var distance = LevenshteinDistance.Compute(str1, str2);
        distance.Should().Be(2);
    }
}