using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Aoc201620;

public class Aoc201620Tests
{
    [Test]
    public void FindsUnblockedIps()
    {
        const string input = """
5-8
0-2
4-7
""";

        var rules = new FirewallRules(input.Trim());
        var lowestIp = rules.GetLowestUnblockedIp();

        Assert.That(lowestIp, Is.EqualTo(3));
    }

    [Test]
    public void AllowedIpCountIsCorrect()
    {
        const string input = """
5-8
0-2
4-7
""";

        var rules = new FirewallRules(input.Trim());
        var lowestIp = rules.GetAllowedIpCount(9);

        Assert.That(lowestIp, Is.EqualTo(2));
    }
}