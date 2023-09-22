using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day07;

public class Year2016Day07 : AocPuzzle
{
    public override string Name => "Internet Protocol Version 7";

    protected override PuzzleResult RunPart1()
    {
        var tester = new IpTester();
        var tlsSupportCount = tester.TlsSupportCount(FileInput);
        return new PuzzleResult(tlsSupportCount, 105);
    }

    protected override PuzzleResult RunPart2()
    {
        var tester = new IpTester();
        var sslSupportCount = tester.SslSupportCount(FileInput);
        return new PuzzleResult(sslSupportCount, 258);
    }
}