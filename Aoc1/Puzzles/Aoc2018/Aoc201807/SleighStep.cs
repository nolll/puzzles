namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201807;

public class SleighStep
{
    public string Name { get; }
    public IList<SleighStep> Deps { get; }

    public SleighStep(string name)
    {
        Name = name;
        Deps = new List<SleighStep>();
    }
}