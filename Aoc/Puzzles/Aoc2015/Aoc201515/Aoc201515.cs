﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201515;

[Name("Science for Hungry People")]
public class Aoc201515 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var bakery = new CookieBakery(input);
        return new PuzzleResult(bakery.HighestScore, "f40d60cbbeb6aff8eff639104c438ab2");
    }

    public PuzzleResult RunPart2(string input)
    {
        var bakery = new CookieBakery(input);
        return new PuzzleResult(bakery.HighestScoreWith500Calories, "b617905d91fbff24a49282c5ea2ec636");
    }
}