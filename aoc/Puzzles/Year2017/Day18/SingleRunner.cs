using System.Collections.Generic;
using Common.Strings;

namespace Aoc.Puzzles.Year2017.Day18;

public class SingleRunner
{
    private readonly IList<string> _operations;

    public long RecoveredFrequency { get; private set; }

    public SingleRunner(string input)
    {
        _operations = PuzzleInputReader.ReadLines(input);
    }

    public void Run()
    {
        var program = new DuetProgramPart1(_operations);
        RecoveredFrequency = program.FindFrequency();
    }
}