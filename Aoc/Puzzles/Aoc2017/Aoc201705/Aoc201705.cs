﻿using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201705;

public class Aoc201705 : AocPuzzle
{
    public override string Name => "A Maze of Twisty Trampolines, All Alike";

    protected override PuzzleResult RunPart1()
    {
        var jumper1 = new InstructionJumper(InputFile);
        jumper1.Start1();
        return new PuzzleResult(jumper1.StepCount, "3893f5208a5bb1ed3716ffb10c7074d1");
    }

    protected override PuzzleResult RunPart2()
    {
        var jumper2 = new InstructionJumper(InputFile);
        jumper2.Start2();
        return new PuzzleResult(jumper2.StepCount, "e9b390d2f610956da9f592bc52c789cc");
    }
}