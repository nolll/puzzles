using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201620;

public class Aoc201620 : AocPuzzle
{
    public override string Name => "Firewall Rules";

    protected override PuzzleResult RunPart1()
    {
        var rules = new FirewallRules(InputFile);
        var ip = rules.GetLowestUnblockedIp();
        return new PuzzleResult(ip, "42063a29b0e82221aa3b4cc217180990");
    }

    protected override PuzzleResult RunPart2()
    {
        var rules = new FirewallRules(InputFile);
        var ipCount = rules.GetAllowedIpCount(Upperbound);
        return new PuzzleResult(ipCount, "38db809093eca7ea30cbfbd9e031ac13");
    }

    private const long Upperbound = 4_294_967_295;
}