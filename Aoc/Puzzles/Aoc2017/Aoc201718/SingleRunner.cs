using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201718;

public class SingleRunner(string input)
{
    private readonly IList<string> _operations = input.Split(LineBreaks.Single);

    public long RecoveredFrequency { get; private set; }

    public void Run()
    {
        var program = new DuetProgramPart1(_operations);
        RecoveredFrequency = program.FindFrequency();
    }
}