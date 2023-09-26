using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202116;

public class Aoc202116 : AocPuzzle
{
    public override string Name => "Packet Decoder";

    protected override PuzzleResult RunPart1()
    {
        var packet = BitsPacket.FromHex(InputFile);
        var result = packet.VersionSum;

        return new PuzzleResult(result, 879);
    }

    protected override PuzzleResult RunPart2()
    {
        var packet = BitsPacket.FromHex(InputFile);
        var result = packet.Value;

        return new PuzzleResult(result, 539051801941);
    }
}