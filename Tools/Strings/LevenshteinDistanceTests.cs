using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Strings;

public class LevenshteinDistanceTests
{
    [TestCase("abcde", "abcde", 0)]
    [TestCase("abcde", "abcdx", 1)]
    [TestCase("abcde", "abcxy", 2)]
    public void Difference(string a, string b, int expected) => 
        LevenshteinDistance.Compute(a, b).Should().Be(expected);
}