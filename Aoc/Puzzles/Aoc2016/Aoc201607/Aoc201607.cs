using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

[Name("Internet Protocol Version 7")]
public class Aoc201607(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var tester = new IpTester();
        var tlsSupportCount = tester.TlsSupportCount(input);
        return new PuzzleResult(tlsSupportCount, "e5028de6073400f8137ef0152f3ce53b");
    }

    protected override PuzzleResult RunPart2()
    {
        var tester = new IpTester();
        var sslSupportCount = tester.SslSupportCount(input);
        return new PuzzleResult(sslSupportCount, "e54678768fabf49128ceb9f16bd2f125");
    }
}