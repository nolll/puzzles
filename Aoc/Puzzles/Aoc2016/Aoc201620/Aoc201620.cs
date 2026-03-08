using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201620;

[Name("Firewall Rules")]
public class Aoc201620 : AocPuzzle
{
    private const long Upperbound = 4_294_967_295;
    
    [Puzzle("42063a29b0e82221aa3b4cc217180990")]
    public long Part1(string input) => new FirewallRules(input).GetLowestUnblockedIp() ?? 0;

    [Puzzle("38db809093eca7ea30cbfbd9e031ac13")]
    public long Part2(string input) => new FirewallRules(input).GetAllowedIpCount(Upperbound);
}