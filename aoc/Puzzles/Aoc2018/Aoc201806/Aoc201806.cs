﻿using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201806;

public class Aoc201806 : AocPuzzle
{
    public override string Name => "Chronal Coordinates";

    protected override PuzzleResult RunPart1()
    {
        var finder = new LargestAreaFinder(InputFile);
        var size = finder.GetSizeOfLargestArea();
        return new PuzzleResult(size, 3223);
    }

    protected override PuzzleResult RunPart2()
    {
        var finder = new LargestAreaFinder(InputFile);
        var size = finder.GetSizeOfCentralArea(10000);
        return new PuzzleResult(size, 40_495);
    }
}