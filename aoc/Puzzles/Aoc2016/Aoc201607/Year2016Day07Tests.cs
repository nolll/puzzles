using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Aoc201607;

public class Year2016Day07Tests
{
    [TestCase("abba[mnop]qrst", true)]
    [TestCase("abcd[bddb]xyyx", false)]
    [TestCase("aaaa[qwer]tyui", false)]
    [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
    public void SupportsTls(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsTls(ip);

        Assert.That(result, Is.EqualTo(result));
    }

    [TestCase("aba[bab]xyz", true)]
    [TestCase("xyx[xyx]xyx", false)]
    [TestCase("aaa[kek]eke", true)]
    [TestCase("zazbz[bzb]cdb", true)]
    public void SupportsSsl(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsSsl(ip);

        Assert.That(result, Is.EqualTo(result));
    }
}