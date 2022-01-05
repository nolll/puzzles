﻿using App.Platform;

namespace App.Puzzles.Year2017.Day11;

public class Year2017Day11 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var navigator = new HexGridNavigator(FileInput);
        return new PuzzleResult(navigator.EndDistance, 808);
    }

    public override PuzzleResult RunPart2()
    {
        var navigator = new HexGridNavigator(FileInput);
        return new PuzzleResult(navigator.MaxDistance, 1556);
    }
}