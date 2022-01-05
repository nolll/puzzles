﻿using App.Platform;

namespace App.Puzzles.Year2021.Day18;

public class Year2021Day18 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var math = new SnailfishMath();
        var result = math.Sum(FileInput);

        return new PuzzleResult(result.Magnitude, 4417);
    }

    public override PuzzleResult RunPart2()
    {
        var math = new SnailfishMath();
        var result = math.LargestMagnitude(FileInput);

        return new PuzzleResult(result, 4796);
    }
}