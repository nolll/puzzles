﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day15;

public class Year2015Day15 : AocPuzzle
{
    public override string Name => "Science for Hungry People";

    protected override PuzzleResult RunPart1()
    {
        var bakery = new CookieBakery(FileInput);
        return new PuzzleResult(bakery.HighestScore, 21_367_368);
    }

    protected override PuzzleResult RunPart2()
    {
        var bakery = new CookieBakery(FileInput);
        return new PuzzleResult(bakery.HighestScoreWith500Calories, 1_766_400);
    }
}