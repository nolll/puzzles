using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day13;

public class Year2017Day13 : AocPuzzle
{
    public override string Name => "Packet Scanners";

    public override PuzzleResult RunPart1()
    {
        var scanner1 = new PacketScanner(FileInput);
        var severity = scanner1.GetSeverity();
        return new PuzzleResult(severity, 1476);
    }

    public override PuzzleResult RunPart2()
    {
        var scanner2 = new PacketScanner(FileInput);
        var delay = scanner2.DelayUntilPass();
        return new PuzzleResult(delay, 3_937_334);
    }
}