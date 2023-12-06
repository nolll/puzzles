using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201505;

public class NaughtyOrNiceEvaluator
{
    private const string Vowels = "aeiou";

    public static int GetNiceCount1(string input)
    {
        var strings = InputReader.ReadLines(input);
        return strings.Count(IsNice1);
    }

    public static int GetNiceCount2(string input)
    {
        var strings = InputReader.ReadLines(input);
        return strings.Count(IsNice2);
    }

    public static bool IsNice1(string input)
    {
        if (ContainsForbiddenSubstrings(input))
            return false;

        if (!ContainsRepeatedCharacter(input))
            return false;

        if (GetVowelCount(input) < 3)
            return false;

        return true;
    }

    public static bool IsNice2(string input) =>
        ContainsRepeatingPair(input) && 
        ContainsRepeatedCharacterWithOneCharacterBetween(input);

    private static bool ContainsRepeatedCharacterWithOneCharacterBetween(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
        {
            var str = input.Substring(i, 3);
            if (str[0] == str[2])
                return true;
        }

        return false;
    }

    private static bool ContainsRepeatingPair(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
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

    private static bool ContainsForbiddenSubstrings(string input) =>
        input.Contains("ab") || 
        input.Contains("cd") || 
        input.Contains("pq") || 
        input.Contains("xy");

    private static bool ContainsRepeatedCharacter(string input)
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

    private static int GetVowelCount(string input) => input.Count(IsVowel);
    private static bool IsVowel(char c) => Vowels.Contains(c);
}