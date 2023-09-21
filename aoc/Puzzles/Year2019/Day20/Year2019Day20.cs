﻿using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day20;

public class Year2019Day20 : AocPuzzle
{
    public override string Title => "Donut Maze";

    public override PuzzleResult RunPart1()
    {
        var mazeSolver = new DonutMazeSolver(FileInput);
        return new PuzzleResult(mazeSolver.ShortestStepCount, 462);
    }

    public override PuzzleResult RunPart2()
    {
        var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(FileInput);
        return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, 5288);
    }
}