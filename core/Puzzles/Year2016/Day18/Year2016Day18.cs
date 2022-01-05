﻿using App.Platform;

namespace App.Puzzles.Year2016.Day18;

public class Year2016Day18 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var detector = new FloorTrapDetector(FileInput);
        var safeCount = detector.CountSafeTiles(40);
        return new PuzzleResult(safeCount, 1989);
    }

    public override PuzzleResult RunPart2()
    {
        var detector = new FloorTrapDetector(FileInput);
        var safeCount = detector.CountSafeTiles(400_000);
        return new PuzzleResult(safeCount, 19_999_894);
    }
}