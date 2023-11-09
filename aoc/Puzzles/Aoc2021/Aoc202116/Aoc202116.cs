using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202116;

public class Aoc202116 : AocPuzzle
{
    public override string Name => "Packet Decoder";

    protected override PuzzleResult RunPart1()
    {
        var packet = BitsPacket.FromHex(InputFile);
        var result = packet.VersionSum;

        return new PuzzleResult(result, "25c39d184ba82383f9e2854e892394d4");
    }

    protected override PuzzleResult RunPart2()
    {
        var packet = BitsPacket.FromHex(InputFile);
        var result = packet.Value;

        return new PuzzleResult(result, "0c7656c225e533d843c1637c804609c8");
    }
}