﻿using App.Platform;

namespace App.Puzzles.Year2016.Day01;

public class Year2016Day01 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(FileInput);
        return new PuzzleResult(calc.DistanceToTarget, 262);
    }

    public override PuzzleResult RunPart2()
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(FileInput);
        return new PuzzleResult(calc.DistanceToFirstRepeat, 131);
    }
}