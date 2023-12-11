﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202212;

[Name("Hill Climbing Algorithm")]
public class Aoc202212(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part1(Input);

        return new PuzzleResult(result, "48b865d6e753e7b8f1cd6f83d797bd43");
    }

    protected override PuzzleResult RunPart2()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part2(Input);

        return new PuzzleResult(result, "222a9519ff249ce48bdd88917bbcc312");
    }
}