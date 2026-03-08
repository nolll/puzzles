using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201713;

[Name("Packet Scanners")]
public class Aoc201713 : AocPuzzle
{
    [Puzzle("760af7f4f4ebd6ba3ffa5e5387041857")]
    public int Part1(string input) => new PacketScanner(input).GetSeverity();

    [Puzzle("0659d62185d9ba0a8fc5c0a3cb87e842")]
    public int Part2(string input) => new PacketScanner(input).DelayUntilPass();
}