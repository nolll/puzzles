﻿using Core.Platform;

namespace Core.Puzzles.Year2022.Day04;

public class Year2022Day04 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part1(FileInput);

        return new PuzzleResult(result, 571);
    }

    public override PuzzleResult RunPart2()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part2(FileInput);

        return new PuzzleResult(result, 917);
    }
}