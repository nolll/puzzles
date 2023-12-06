using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

public class Aoc201607 : AocPuzzle
{
    public override string Name => "Internet Protocol Version 7";

    protected override PuzzleResult RunPart1()
    {
        var tester = new IpTester();
        var tlsSupportCount = tester.TlsSupportCount(InputFile);
        return new PuzzleResult(tlsSupportCount, "e5028de6073400f8137ef0152f3ce53b");
    }

    protected override PuzzleResult RunPart2()
    {
        var tester = new IpTester();
        var sslSupportCount = tester.SslSupportCount(InputFile);
        return new PuzzleResult(sslSupportCount, "e54678768fabf49128ceb9f16bd2f125");
    }
}