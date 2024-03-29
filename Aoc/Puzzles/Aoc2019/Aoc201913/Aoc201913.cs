﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201913;

[Name("Care Package")]
public class Aoc201913(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var arcade = new Arcade(input);
        arcade.Play();

        return new PuzzleResult(arcade.NumberOfBlockTiles, "65621a57e5ba6bbdc37540f0d2320098");
    }

    protected override PuzzleResult RunPart2()
    {
        var arcade = new Arcade(input);
        arcade.Play(2);

        return new PuzzleResult(arcade.Score, "6c32f2b8d2a26180534728ccb213e116");
    }
}