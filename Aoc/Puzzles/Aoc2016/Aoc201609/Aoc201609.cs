using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201609;

[Name("Explosives in Cyberspace")]
public class Aoc201609 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var decompressor = new FileDecompressor(InputFile);
        return new PuzzleResult(decompressor.DecompressedLengthV1, "963b04cd929c376aa9a75d813a774205");
    }

    protected override PuzzleResult RunPart2()
    {
        var decompressor = new FileDecompressor(InputFile);
        return new PuzzleResult(decompressor.DecompressedLengthV2, "bfe4afdea90f1f177895b3bbde55f5a5");
    }
}