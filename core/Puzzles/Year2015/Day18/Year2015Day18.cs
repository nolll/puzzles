﻿using App.Platform;

namespace App.Puzzles.Year2015.Day18;

public class Year2015Day18 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var gif = new AnimatedGif(FileInput);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, 821);
    }

    public override PuzzleResult RunPart2()
    {
        var gif = new AnimatedGif(FileInput, true);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, 886);
    }
}