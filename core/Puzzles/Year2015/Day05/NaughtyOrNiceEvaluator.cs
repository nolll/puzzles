using System;
using System.Linq;

namespace Core.Puzzles.Year2015.Day05;

public class NaughtyOrNiceEvaluator
{
    private const string Vowels = "aeiou";

    public int GetNiceCount1(string input)
    {
        var strings = input.Split('\n').Select(o => o.Trim());
        return strings.Count(IsNice1);
    }

    public int GetNiceCount2(string input)
    {
        var strings = input.Split('\n').Select(o => o.Trim());
        return strings.Count(IsNice2);
    }

    public bool IsNice1(string input)
    {
        if (ContainsForbiddenSubstrings(input))
            return false;

        if (!ContainsRepeatedCharacter(input))
            return false;

        if (GetVowelCount(input) < 3)
            return false;

        return true;
    }

    public bool IsNice2(string input)
    {
        if (!ContainsRepeatingPair(input))
            return false;

        if (!ContainsRepeatedCharacterWithOneCharacterBetween(input))
            return false;

        return true;
    }

    private bool ContainsRepeatedCharacterWithOneCharacterBetween(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
        {
            var str = input.Substring(i, 3);
            if (str[0] == str[2])
                return true;
        }

        return false;
    }

    private bool ContainsRepeatingPair(string input)
    {
        for (var i = 0; i < input.Length - 1; i++)
        {
            var str = input.Substring(i, 2);
            var firstOccurence = input.IndexOf(str, StringComparison.InvariantCulture);
            var lastOccurence = input.LastIndexOf(str, StringComparison.InvariantCulture);
            var diff = lastOccurence - firstOccurence;

            if (diff > 1)
                return true;
        }

        return false;
    }

    private bool ContainsForbiddenSubstrings(string input)
    {
        if (input.Contains("ab"))
            return true;
        if (input.Contains("cd"))
            return true;
        if (input.Contains("pq"))
            return true;
        if (input.Contains("xy"))
            return true;
        return false;
    }

    private bool ContainsRepeatedCharacter(string input)
    {
        var lastChar = '-';
        foreach (var c in input)
        {
            if (c == lastChar)
                return true;

            lastChar = c;
        }

        return false;
    }

    private int GetVowelCount(string input)
    {
        return input.Count(IsVowel);
    }

    private bool IsVowel(char c)
    {
        return Vowels.Contains(c);
    }
}