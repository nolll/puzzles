﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day09;

public class Year2016Day09 : AocPuzzle
{
    public override string Title => "Explosives in Cyberspace";

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