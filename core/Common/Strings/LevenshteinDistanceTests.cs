using NUnit.Framework;

namespace Core.Common.Strings;

public class LevenshteinDistanceTests
{
    [Test]
    public void NoDifference()
    {
        const string str = "abcde";
        var distance = LevenshteinDistance.Compute(str, str);
        Assert.AreEqual(0, distance);
    }

    [Test]
    public void OneCharDifference()
    {
        const string str1 = "abcde";
        const string str2 = "abcdX";
        var distance = LevenshteinDistance.Compute(str1, str2);
        Assert.AreEqual(1, distance);
    }

    [Test]
    public void TwoCharDifference()
    {
        const string str1 = "abcde";
        const string str2 = "abcXY";
        var distance = LevenshteinDistance.Compute(str1, str2);
        Assert.AreEqual(2, distance);
    }
}