﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day19;

public class Year2020Day19 : AocPuzzle
{
    public override string Title => "Monster Messages";

    public override PuzzleResult RunPart1()
    {
        var validator = new MonsterImageValidator(FileInput);
        var result = validator.ValidCount();
        return new PuzzleResult(result, 122);
    }

    public override PuzzleResult RunPart2()
    {
        var validator = new MonsterImageValidator(FileInput, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result, 287);
    }
}