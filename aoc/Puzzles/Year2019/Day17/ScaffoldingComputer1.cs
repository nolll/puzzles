﻿using System.Text;
using common.Computers.IntCode;

namespace Aoc.Puzzles.Year2019.Day17;

public class ScaffoldingComputer1
{
    private readonly IntCodeComputer _computer;
    private readonly StringBuilder _sb;

    public ScaffoldingComputer1(string program)
    {
        _sb = new StringBuilder();
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
    }

    public string Run()
    {
        _computer.Start();
        return _sb.ToString();
    }

    private long ReadInput()
    {
        return 0;
    }

    private bool WriteOutput(long output)
    {
        _sb.Append((char)output);
        return true;
    }
}