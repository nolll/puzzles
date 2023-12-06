using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201718;

public class SingleRunner
{
    private readonly IList<string> _operations;

    public long RecoveredFrequency { get; private set; }

    public SingleRunner(string input)
    {
        _operations = InputReader.ReadLines(input);
    }

    public void Run()
    {
        var program = new DuetProgramPart1(_operations);
        RecoveredFrequency = program.FindFrequency();
    }
}