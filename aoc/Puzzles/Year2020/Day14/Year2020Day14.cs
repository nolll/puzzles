﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day14;

public class Year2020Day14 : AocPuzzle
{
    public override string Title => "Docking Data";

    public override PuzzleResult RunPart1()
    {
        var system = new BitmaskSystem1();
        var sum = system.Run(FileInput);
        return new PuzzleResult(sum, 11_179_633_149_677);
    }

    public override PuzzleResult RunPart2()
    {
        var system = new BitmaskSystem2();
        var sum = system.Run(FileInput);
        return new PuzzleResult(sum, 4_822_600_194_774);
    }
}