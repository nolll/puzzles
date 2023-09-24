using System.Linq;

namespace Aoc.Puzzles.Aoc2016.Aoc201621;

public abstract class RotateInstruction : IScrambleInstruction
{
    public abstract string Run(string s);
    public abstract string RunBackwards(string s);

    protected string RotateRight(string s, int steps)
    {
        var letters = s.ToList();
        for (var i = 0; i < steps; i++)
        {
            var letterToMove = letters.Last();
            letters.RemoveAt(letters.Count - 1);
            letters.Insert(0, letterToMove);
        }

        return string.Concat(letters);
    }

    protected string RotateLeft(string s, int steps)
    {
        var letters = s.ToList();
        for (var i = 0; i < steps; i++)
        {
            var letterToMove = letters.First();
            letters.RemoveAt(0);
            letters.Add(letterToMove);
        }

        return string.Concat(letters);
    }
}