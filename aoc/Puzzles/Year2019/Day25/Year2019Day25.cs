﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day25;

public class Year2019Day25 : AocPuzzle
{
    public override string Name => "Cryostasis";

    protected override PuzzleResult RunPart1()
    {
        var investigationDroid = new InvestigationDroid(FileInput);
        var password = investigationDroid.Run();

        return new PuzzleResult(password, "285213704");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}