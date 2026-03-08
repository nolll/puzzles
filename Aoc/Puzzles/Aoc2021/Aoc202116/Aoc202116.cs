using System.Numerics;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202116;

[Name("Packet Decoder")]
public class Aoc202116 : AocPuzzle
{
    [Puzzle("25c39d184ba82383f9e2854e892394d4")]
    public int Part1(string input) => BitsPacket.FromHex(input).VersionSum;

    [Puzzle("0c7656c225e533d843c1637c804609c8")]
    public BigInteger Part2(string input) => BitsPacket.FromHex(input).Value;
}