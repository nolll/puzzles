using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201609;

[Name("Explosives in Cyberspace")]
public class Aoc201609 : AocPuzzle
{
    [Puzzle("963b04cd929c376aa9a75d813a774205")]
    public int Part1(string input) => new FileDecompressor(input).DecompressedLengthV1;

    [Puzzle("bfe4afdea90f1f177895b3bbde55f5a5")]
    public long Part2(string input) => new FileDecompressor(input).DecompressedLengthV2;
}