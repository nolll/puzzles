﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day02;

public class Year2016Day02 : AocPuzzle
{
    public override string Name => "Bathroom Security";

    protected override PuzzleResult RunPart1()
    {
        var squareCodeFinder = new SquareKeyCodeFinder();
        var squareCode = squareCodeFinder.Find(FileInput);
        return new PuzzleResult(squareCode, "61529");
    }

    protected override PuzzleResult RunPart2()
    {
        var diamondCodeFinder = new DiamondKeyCodeFinder();
        var diamondCode = diamondCodeFinder.Find(FileInput);
        return new PuzzleResult(diamondCode, "C2C28");
    }
}