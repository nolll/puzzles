using Core.Platform;

namespace Core.Puzzles.Year2016.Day09;

public class Year2016Day09 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var decompressor = new FileDecompressor(FileInput);
        return new PuzzleResult(decompressor.DecompressedLengthV1, 107_035);
    }

    public override PuzzleResult RunPart2()
    {
        var decompressor = new FileDecompressor(FileInput);
        return new PuzzleResult(decompressor.DecompressedLengthV2, 11_451_628_995);
    }
}