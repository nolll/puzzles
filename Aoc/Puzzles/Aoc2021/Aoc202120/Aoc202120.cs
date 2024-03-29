﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202120;

[Name("Trench Map")]
public class Aoc202120(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(input, 2);

        return new PuzzleResult(result, "45662f27fb9cbf099b4d5453539159a2");
    }

    protected override PuzzleResult RunPart2()
    {
        var trenchMap = new TrenchMap();
        var result = trenchMap.GetLitPixelCount(input, 50);

        return new PuzzleResult(result, "0225d04616fb918456e876afd4831afd");
    }
}