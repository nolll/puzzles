﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day25;

public class Year2021Day25 : AocPuzzle
{
    public override string Title => "Sea Cucumber";

    public override PuzzleResult RunPart1()
    {
        var herd = new HerdOfSeaCucumbers(FileInput);
        var result = herd.MoveUntilStop();

        return new PuzzleResult(result, 518);
    }

    public override PuzzleResult RunPart2() => PuzzleResult.Empty();
}