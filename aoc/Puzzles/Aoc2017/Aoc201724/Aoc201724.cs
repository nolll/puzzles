﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201724;

public class Aoc201724 : AocPuzzle
{
    public override string Name => "Electromagnetic Moat";

    protected override PuzzleResult RunPart1()
    {
        var builder1 = new BridgeBuilder(InputFile, false);
        var bridge1 = builder1.Build();
        return new PuzzleResult(bridge1.Strength, 1940);
    }

    protected override PuzzleResult RunPart2()
    {
        var builder2 = new BridgeBuilder(InputFile, true);
        var bridge2 = builder2.Build();
        return new PuzzleResult(bridge2.Strength, 1928);
    }
}