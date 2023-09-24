using System.Linq;

namespace Aoc.Puzzles.Aoc2016.Aoc201621;

public class MoveInstruction : IScrambleInstruction
{
    private readonly int _from;
    private readonly int _to;

    public MoveInstruction(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public string Run(string s)
    {
        return Move(s, _from, _to);
    }
        
    public string RunBackwards(string s)
    {
        return Move(s, _to, _from);
    }

    private string Move(string s, int from, int to)
    {
        var letters = s.ToList();
        var letterToMove = s.Skip(from).Take(1).First();
        letters.RemoveAt(from);
        letters.Insert(to, letterToMove);
        return string.Concat(letters);
    }
}