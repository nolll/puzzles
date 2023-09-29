﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201604;

public class Aoc201604 : AocPuzzle
{
    public override string Name => "Security Through Obscurity";

    protected override PuzzleResult RunPart1()
    {
        var validator = new RoomValidator(InputFile);
        var sum = validator.SumOfIds;
        return new PuzzleResult(sum, 278_221);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new RoomValidator(InputFile);
        return new PuzzleResult(validator.NorthpoleObjectStorageId, 267);
    }
}