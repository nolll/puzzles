﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202017;

[Name("Conway Cubes")]
public class Aoc202017(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var cube = new ConwayCube();
        var result = cube.Boot3D(input, 6);
        return new PuzzleResult(result, "86fb7e6bf0dd282e332fdf0fe14cb572");
    }

    protected override PuzzleResult RunPart2()
    {
        var cube = new ConwayCube();
        var result = cube.Boot4D(input, 6);
        return new PuzzleResult(result, "7d43e2d315b28ef823069e2b5aef74e8");
    }
}