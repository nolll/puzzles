using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

public class Aoc201607Tests
{
    [TestCase("abba[mnop]qrst", true)]
    [TestCase("abcd[bddb]xyyx", false)]
    [TestCase("aaaa[qwer]tyui", false)]
    [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
    public void SupportsTls(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsTls(ip);

        result.Should().Be(result);
    }

    [TestCase("aba[bab]xyz", true)]
    [TestCase("xyx[xyx]xyx", false)]
    [TestCase("aaa[kek]eke", true)]
    [TestCase("zazbz[bzb]cdb", true)]
    public void SupportsSsl(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsSsl(ip);

        result.Should().Be(result);
    }
}