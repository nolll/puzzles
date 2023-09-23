﻿using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day07;

public class Year2018Day07 : AocPuzzle
{
    public override string Name => "The Sum of Its Parts";

    protected override PuzzleResult RunPart1()
    {
        var assembler1 = new SleighAssembler(FileInput, 1, 0);
        var result1 = assembler1.Assemble();
        return new PuzzleResult(result1.Order, "CQSWKZFJONPBEUMXADLYIGVRHT");
    }

    protected override PuzzleResult RunPart2()
    {
        var assembler2 = new SleighAssembler(FileInput, 5, 60);
        var result2 = assembler2.Assemble();
        return new PuzzleResult(result2.Time, 914);
    }
}