﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day09;

public class Year2018Day09 : AocPuzzle
{
    public override string Name => "Marble Mania";

    protected override PuzzleResult RunPart1()
    {
        var game = MarbleGame.Parse(FileInput);
        return new PuzzleResult(game.WinnerScore, 434_674);
    }

    protected override PuzzleResult RunPart2()
    {
        var game2 = MarbleGame.Parse(FileInput, 100);
        return new PuzzleResult(game2.WinnerScore, 3_653_994_575);
    }
}