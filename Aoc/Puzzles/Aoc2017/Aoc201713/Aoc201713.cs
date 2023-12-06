using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201713;

public class Aoc201713 : AocPuzzle
{
    public override string Name => "Packet Scanners";

    protected override PuzzleResult RunPart1()
    {
        var scanner1 = new PacketScanner(InputFile);
        var severity = scanner1.GetSeverity();
        return new PuzzleResult(severity, "760af7f4f4ebd6ba3ffa5e5387041857");
    }

    protected override PuzzleResult RunPart2()
    {
        var scanner2 = new PacketScanner(InputFile);
        var delay = scanner2.DelayUntilPass();
        return new PuzzleResult(delay, "0659d62185d9ba0a8fc5c0a3cb87e842");
    }
}