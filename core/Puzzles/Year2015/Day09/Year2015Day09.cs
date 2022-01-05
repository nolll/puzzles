﻿using App.Platform;

namespace App.Puzzles.Year2015.Day09;

public class Year2015Day09 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var calculator = new RouteCalculator(FileInput);
        return new PuzzleResult(calculator.ShortestDistance, 117);
    }

    public override PuzzleResult RunPart2()
    {
        var calculator = new RouteCalculator(FileInput);
        return new PuzzleResult(calculator.LongestDistance, 909);
    }
}