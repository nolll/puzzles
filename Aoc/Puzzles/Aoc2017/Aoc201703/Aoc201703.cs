﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201703;

[Name("Spiral Memory")]
public class Aoc201703(string input) : AocPuzzle
{
    private int IntInput => int.Parse(input);

    protected override PuzzleResult RunPart1()
    {
        var memory1 = new SpiralMemory(IntInput, SpiralMemoryMode.RunToTarget);
        return new PuzzleResult(memory1.Distance, "748d6bb1c2e5af3bdc9deece20b7d9f5");
    }

    protected override PuzzleResult RunPart2()
    {
        var memory2 = new SpiralMemory(IntInput, SpiralMemoryMode.RunToValue);
        return new PuzzleResult(memory2.Value, "5378201bd68f309919ec6a47cde9888d");
    }
}