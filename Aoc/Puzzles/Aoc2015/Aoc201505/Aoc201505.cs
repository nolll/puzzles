using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201505;

[Name("Doesn't He Have Intern-Elves For This?")]
public class Aoc201505 : AocPuzzle
{
    [Puzzle("9acaaf3fc5bc7b60d024ccf5dee1c098")]
    public int Part1(string input) => GetNiceCount1(input);

    [Puzzle("5363390b461681375e68f3cea9b968df")]
    public int Part2(string input) => GetNiceCount2(input);

    private const string Vowels = "aeiou";

    private static int GetNiceCount1(string input) => input.Split(LineBreaks.Single).Count(IsNice1);
    private static int GetNiceCount2(string input) => input.Split(LineBreaks.Single).Count(IsNice2);

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