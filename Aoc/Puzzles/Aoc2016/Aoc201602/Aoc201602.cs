﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201602;

[Name("Bathroom Security")]
public class Aoc201602(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var squareCodeFinder = new SquareKeyCodeFinder();
        var squareCode = squareCodeFinder.Find(input);
        return new PuzzleResult(squareCode, "bc6c7825d96d5406ad3776a37c342187");
    }

    protected override PuzzleResult RunPart2()
    {
        var diamondCodeFinder = new DiamondKeyCodeFinder();
        var diamondCode = diamondCodeFinder.Find(input);
        return new PuzzleResult(diamondCode, "e0e405db166ec0ceae706cf925ff34a9");
    }
}