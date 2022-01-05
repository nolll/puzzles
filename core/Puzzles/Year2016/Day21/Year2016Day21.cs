﻿using App.Platform;

namespace App.Puzzles.Year2016.Day21;

public class Year2016Day21 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var scrambler = new StringScrambler(FileInput);
        var scrambled = scrambler.Scramble("abcdefgh");
        return new PuzzleResult(scrambled, "dbfgaehc");
    }

    public override PuzzleResult RunPart2()
    {
        var scrambler = new StringScrambler(FileInput);
        var unscrambled = scrambler.Unscramble("fbgdceah");
        return new PuzzleResult(unscrambled, "aghfcdeb");
    }
}