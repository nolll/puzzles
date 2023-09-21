using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day16;

public class Year2021Day16 : AocPuzzle
{
    public override string Title => "Packet Decoder";

    public override PuzzleResult RunPart1()
    {
        var packet = BitsPacket.FromHex(FileInput);
        var result = packet.VersionSum;

        return new PuzzleResult(result, 879);
    }

    public override PuzzleResult RunPart2()
    {
        var packet = BitsPacket.FromHex(FileInput);
        var result = packet.Value;

        return new PuzzleResult(result, 539051801941);
    }
}