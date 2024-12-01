using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201620;

[Name("Firewall Rules")]
public class Aoc201620 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var rules = new FirewallRules(input);
        var ip = rules.GetLowestUnblockedIp();
        return new PuzzleResult(ip, "42063a29b0e82221aa3b4cc217180990");
    }

    public PuzzleResult RunPart2(string input)
    {
        var rules = new FirewallRules(input);
        var ipCount = rules.GetAllowedIpCount(Upperbound);
        return new PuzzleResult(ipCount, "38db809093eca7ea30cbfbd9e031ac13");
    }

    private const long Upperbound = 4_294_967_295;
}