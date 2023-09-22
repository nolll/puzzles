﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day11;

public class Year2017Day11 : AocPuzzle
{
    public override string Name => "Hex Ed";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new HexGridNavigator(FileInput);
        return new PuzzleResult(navigator.EndDistance, 808);
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new HexGridNavigator(FileInput);
        return new PuzzleResult(navigator.MaxDistance, 1556);
    }
}