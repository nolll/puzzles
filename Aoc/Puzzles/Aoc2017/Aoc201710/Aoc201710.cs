using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201710;

[Name("Knot Hash")]
public class Aoc201710 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var intHasher = new IntKnotHasher(InputFile);
        return new PuzzleResult(intHasher.Checksum, "9c105df09bcd0a4924f4fd2f82cc37db");
    }

    protected override PuzzleResult RunPart2()
    {
        var asciiHasher = new AsciiKnotHasher(InputFile);
        return new PuzzleResult(asciiHasher.Hash, "184cedf831647600e6b64716e141b2e9");
    }
}