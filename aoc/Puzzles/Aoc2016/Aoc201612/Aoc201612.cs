﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201612;

public class Aoc201612 : AocPuzzle
{
    public override string Name => "Leonardo's Monorail";

    protected override PuzzleResult RunPart1()
    {
        var computer = new MonorailComputer(InputFile, 0, 0);
        return new PuzzleResult(computer.ValueA, 318_003);
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new MonorailComputer(InputFile, 0, 1);
        return new PuzzleResult(computer.ValueA, 9_227_657);
    }
}