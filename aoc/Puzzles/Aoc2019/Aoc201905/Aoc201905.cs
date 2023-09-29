﻿using Common.Computers.IntCode;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201905;

public class Aoc201905 : AocPuzzle
{
    private long _output;

    public override string Name => "Sunny with a Chance of Asteroids";

    protected override PuzzleResult RunPart1()
    {
        var ci1 = new IntCodeComputer(InputFile, ReadInputPart1, WriteOutput);
        ci1.Start();

        return new PuzzleResult(_output, 5_346_030);
    }

    protected override PuzzleResult RunPart2()
    {
        var ci2 = new IntCodeComputer(InputFile, ReadInputPart2, WriteOutput);
        ci2.Start();

        return new PuzzleResult(_output, 513_116);
    }

    private long ReadInputPart1() => 1;
    private long ReadInputPart2() => 5;

    private bool WriteOutput(long output)
    {
        _output = output;
        return true;
    }
}