﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day02;

public class Year2015Day02 : AocPuzzle
{
    public override string Title => "I Was Told There Would Be No Math";

    public override PuzzleResult RunPart1()
    {
        var paperResult = GiftWrappingCalculator.GetRequiredPaper(FileInput);

        return new PuzzleResult(paperResult, 1_606_483);
    }

    public override PuzzleResult RunPart2()
    {
        var ribbonResult = GiftWrappingCalculator.GetRequiredRibbon(FileInput);
            
        return new PuzzleResult(ribbonResult, 3_842_356);
    }
}