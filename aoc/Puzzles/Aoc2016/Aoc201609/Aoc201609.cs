using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201609;

public class Aoc201609 : AocPuzzle
{
    public override string Name => "Explosives in Cyberspace";

    protected override PuzzleResult RunPart1()
    {
        var decompressor = new FileDecompressor(InputFile);
        return new PuzzleResult(decompressor.DecompressedLengthV1, 107_035);
    }

    protected override PuzzleResult RunPart2()
    {
        var decompressor = new FileDecompressor(InputFile);
        return new PuzzleResult(decompressor.DecompressedLengthV2, 11_451_628_995);
    }
}