﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

[Name("Donut Maze")]
public class Aoc201920(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var mazeSolver = new DonutMazeSolver(Input);
        return new PuzzleResult(mazeSolver.ShortestStepCount, "58adb5666e2e47bbe945955687e3e3c6");
    }

    protected override PuzzleResult RunPart2()
    {
        var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(Input);
        return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, "01cf53a29e92f3092e973f5c97ac5595");
    }
}