﻿using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day14;

public class Year2021Day14 : AocPuzzle
{
    public override string Name => "Extended Polymerization";

    protected override PuzzleResult RunPart1()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(FileInput, 10);

        return new PuzzleResult(result, 3247);
    }

    protected override PuzzleResult RunPart2()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(FileInput, 40);

        return new PuzzleResult(result, 4110568157153);
    }
}