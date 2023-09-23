﻿using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day13;

public class Year2016Day13 : AocPuzzle
{
    public override string Name => "A Maze of Twisty Little Cubicles";

    protected override PuzzleResult RunPart1()
    {
        var maze = new Maze(50, 50, Input);
        var stepCount = maze.StepCountToTarget(31, 39);
        return new PuzzleResult(stepCount, 82);
    }

    protected override PuzzleResult RunPart2()
    {
        var maze = new Maze(75, 75, Input);
        var locationCount = maze.LocationCountAfter(50);
        return new PuzzleResult(locationCount, 138);
    }

    private const int Input = 1362;
}