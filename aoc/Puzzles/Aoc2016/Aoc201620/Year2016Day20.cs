using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201620;

public class Year2016Day20 : AocPuzzle
{
    public override string Name => "Firewall Rules";

    protected override PuzzleResult RunPart1()
    {
        var rules = new FirewallRules(InputFile);
        var ip = rules.GetLowestUnblockedIp();
        return new PuzzleResult(ip, 14_975_795);
    }

    protected override PuzzleResult RunPart2()
    {
        var rules = new FirewallRules(InputFile);
        var ipCount = rules.GetAllowedIpCount(Upperbound);
        return new PuzzleResult(ipCount, 101);
    }

    private const long Upperbound = 4_294_967_295;
}