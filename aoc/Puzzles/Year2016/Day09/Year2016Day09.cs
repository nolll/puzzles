using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day09;

public class Year2016Day09 : AocPuzzle
{
    public override string Name => "Explosives in Cyberspace";

    protected override PuzzleResult RunPart1()
    {
        var decompressor = new FileDecompressor(FileInput);
        return new PuzzleResult(decompressor.DecompressedLengthV1, 107_035);
    }

    protected override PuzzleResult RunPart2()
    {
        var decompressor = new FileDecompressor(FileInput);
        return new PuzzleResult(decompressor.DecompressedLengthV2, 11_451_628_995);
    }
}