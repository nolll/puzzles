using System.Linq;

namespace Core.Puzzles.Year2016.Day21;

public class SwapLetterInstruction : IScrambleInstruction
{
    private readonly char _a;
    private readonly char _b;

    public SwapLetterInstruction(char a, char b)
    {
        _a = a;
        _b = b;
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
        var letterAPos = letters.IndexOf(_a);
        var letterBPos = letters.IndexOf(_b);
        letters[letterAPos] = _b;
        letters[letterBPos] = _a;
        return string.Concat(letters);
    }
}