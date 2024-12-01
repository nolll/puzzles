using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201710;

[Name("Knot Hash")]
public class Aoc201710 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var intHasher = new IntKnotHasher(input);
        return new PuzzleResult(intHasher.Checksum, "9c105df09bcd0a4924f4fd2f82cc37db");
    }

    public PuzzleResult RunPart2(string input)
    {
        var asciiHasher = new AsciiKnotHasher(input);
        return new PuzzleResult(asciiHasher.Hash, "184cedf831647600e6b64716e141b2e9");
    }
}