﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202009;

public class Aoc202009 : AocPuzzle
{
    public override string Name => "Encoding Error";

    protected override PuzzleResult RunPart1()
    {
        var port = new XmasPort(InputFile, 25);
        var invalidNumber = port.FindFirstInvalidNumber();
        return new PuzzleResult(invalidNumber, 32321523);
    }

    protected override PuzzleResult RunPart2()
    {
        var port = new XmasPort(InputFile, 25);
        var weakness = port.FindWeakness();
        return new PuzzleResult(weakness, 4794981);
    }
}