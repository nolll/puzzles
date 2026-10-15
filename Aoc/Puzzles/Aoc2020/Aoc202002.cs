using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Password Philosophy")]
public class Aoc202002 : AocPuzzle
{
    [Puzzle("ebf6e414ef8abc275a90f1a99df980cf")]
    public int Part1(string input) => input.Split(LineBreaks.Single).Count(IsValid1);

    [Puzzle("0bcc20cf5a222049f20c6e88aa2731a9")]
    public int Part2(string input) => input.Split(LineBreaks.Single).Count(IsValid2);

    public bool IsValid1(string policy)
    {
        var (c, pwd, lowerBound, upperBound) = Parse(policy);
        var validLetterCount = pwd.Count(o => o == c);
        return validLetterCount >= lowerBound && validLetterCount <= upperBound;
    }

    public bool IsValid2(string policy)
    {
        var (c, pwd, lowerBound, upperBound) = Parse(policy);
        var firstPosition = lowerBound - 1;
        var secondPosition = upperBound - 1;
        var firstMatch = pwd[firstPosition] == c;
        var secondMatch = pwd[secondPosition] == c;
        var isBothMatch = firstMatch && secondMatch;
        var isOneMatch = firstMatch || secondMatch;

        return isOneMatch && !isBothMatch;
    }

    private static (char c, string pwd, int lowerBound, int upperBound) Parse(string input)
    {
        var parts = input.Split(": ");
        var ruleParts = parts[0].Split(' ');
        var c = ruleParts[1][0];
        var pwd = parts[1];
        var bounds = ruleParts[0].Split('-');
        var lowerBound = int.Parse(bounds[0]);
        var upperBound = int.Parse(bounds[1]);

        return (c, pwd, lowerBound, upperBound);
    }
}