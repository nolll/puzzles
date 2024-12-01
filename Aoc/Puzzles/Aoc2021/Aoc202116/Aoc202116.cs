using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202116;

[Name("Packet Decoder")]
public class Aoc202116 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var packet = BitsPacket.FromHex(input);
        var result = packet.VersionSum;

        return new PuzzleResult(result, "25c39d184ba82383f9e2854e892394d4");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var packet = BitsPacket.FromHex(input);
        var result = packet.Value;

        return new PuzzleResult(result, "0c7656c225e533d843c1637c804609c8");
    }
}