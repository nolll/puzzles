namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201621;

public class SwapPositionInstruction : IScrambleInstruction
{
    private readonly int _from;
    private readonly int _to;

    public SwapPositionInstruction(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public string Run(string s)
    {
        return Swap(s);
    }

    public string RunBackwards(string s)
    {
        return Swap(s);
    }

    private string Swap(string s)
    {
        var letters = s.ToList();
        var letterA = letters[_from];
        var letterB = letters[_to];
        letters[_from] = letterB;
        letters[_to] = letterA;
        return string.Concat(letters);
    }
}