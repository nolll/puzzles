namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201621;

public class ReverseInstruction : IScrambleInstruction
{
    private readonly int _from;
    private readonly int _to;

    public ReverseInstruction(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public string Run(string s)
    {
        return Reverse(s);
    }

    public string RunBackwards(string s)
    {
        return Reverse(s);
    }

    private string Reverse(string s)
    {
        var letters = s.ToList();
        var startRange = letters.Take(_from);
        var endRange = letters.Skip(_to + 1);
        var range = letters.Skip(_from).Take(_to + 1 - _from);
        return string.Concat(startRange.Concat(range.Reverse()).Concat(endRange).ToList());
    }
}