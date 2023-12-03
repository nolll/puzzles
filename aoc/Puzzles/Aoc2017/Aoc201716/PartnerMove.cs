namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201716;

public class PartnerMove : DanceMove
{
    private readonly char _val1;
    private readonly char _val2;

    public PartnerMove(string command)
    {
        var parts = command.Substring(1).Split('/').Select(o => o.First()).ToList();
        _val1 = parts[0];
        _val2 = parts[1];
    }

    public override void Execute(IDictionary<char, int> programs)
    {
        var index1 = programs[_val1];
        var index2 = programs[_val2];
        programs[_val1] = index2;
        programs[_val2] = index1;
    }
}