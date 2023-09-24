using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day13;

public class Year2017Day13 : AocPuzzle
{
    public override string Name => "Packet Scanners";

    protected override PuzzleResult RunPart1()
    {
        var scanner1 = new PacketScanner(InputFile);
        var severity = scanner1.GetSeverity();
        return new PuzzleResult(severity, 1476);
    }

    protected override PuzzleResult RunPart2()
    {
        var scanner2 = new PacketScanner(InputFile);
        var delay = scanner2.DelayUntilPass();
        return new PuzzleResult(delay, 3_937_334);
    }
}