﻿using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day20;

public class Year2021Day20 : AocPuzzle
{
    public override string Name => "Trench Map";

    protected override PuzzleResult RunPart1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(FileInput, 2);

        return new PuzzleResult(result, 5765);
    }

    protected override PuzzleResult RunPart2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(FileInput, 50);

        return new PuzzleResult(result, 18509);
    }
}