namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201620;

public class Aoc201620Tests
{
    [Fact]
    public void FindsUnblockedIps()
    {
        const string input = """
                             5-8
                             0-2
                             4-7
                             """;

        var rules = new FirewallRules(input.Trim());
        var lowestIp = rules.GetLowestUnblockedIp();

        lowestIp.Should().Be(3);
    }

    [Fact]
    public void AllowedIpCountIsCorrect()
    {
        const string input = """
                             5-8
                             0-2
                             4-7
                             """;

        var rules = new FirewallRules(input.Trim());
        var lowestIp = rules.GetAllowedIpCount(9);

        lowestIp.Should().Be(2);
    }
}