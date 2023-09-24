using System.Linq;

namespace Aoc.Puzzles.Aoc2017.Aoc201704;

public class PassphraseValidator
{
    public int GetValidCount1(string input)
    {
        return input.Split('\n').Count(IsValid1);
    }

    public int GetValidCount2(string input)
    {
        return input.Split('\n').Count(IsValid2);
    }

    public bool IsValid1(string input)
    {
        var words = input.Split(" ").Select(o => o.Trim()).ToList();
        foreach (var word in words)
        {
            if (words.Count(o => o == word) > 1)
                return false;
        }

        return true;
    }

    public bool IsValid2(string input)
    {
        var words = input.Split(" ").Select(o => string.Concat(o.Trim().OrderBy(c => c))).ToList();
        foreach (var word in words)
        {
            if (words.Count(o => o == word) > 1)
                return false;
        }

        return true;
    }
}