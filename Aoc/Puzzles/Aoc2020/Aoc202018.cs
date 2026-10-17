using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Operation Order")]
public class Aoc202018 : AocPuzzle
{
    private const string Addition = "+";
    private const string Multiplication = "*";
    private const char GroupStart = '(';
    private const char GroupEnd = ')';

    private static readonly Regex GroupingRegex = new(@"\([0-9 \*\+]+\)");
    
    [Puzzle("4a4cb1e5143143fe556872f0d8ace4bc")]
    public long Part1(string input) => Solve(input, CalcWithOrderPrecedence);

    [Puzzle("f4ba1f258e57a75e7a35552abca1311f")]
    public long Part2(string input) => Solve(input, CalcWithAdditionPrecedence);

    private static long Solve(string input, Func<string, long> calcFunc) =>
        input.Split(LineBreaks.Single).Sum(o => Sum(o, calcFunc));

    private static long Sum(string input, Func<string, long> calc) => Calculate(input, calc);

    private static long Calculate(string s, Func<string, long> calc)
    {
        while (s.Contains('('))
        {
            var matches = GroupingRegex.Matches(s);
            foreach (Match match in matches)
            {
                var hit = match.ToString();
                var result = calc(hit.TrimStart(GroupStart).TrimEnd(GroupEnd));
                s = s.Replace(hit, result.ToString());
            }
        }

        return calc(s);
    }

    private static long CalcWithOrderPrecedence(string s)
    {
        var parts = s.Split(' ').ToList();
        while (parts.Count > 1)
        {
            var current = long.Parse(parts[0]);
            var next = long.Parse(parts[2]);
            var operation = parts[1];
            var result = operation == Multiplication
                ? current * next
                : current + next;

            parts[0] = result.ToString();
            parts.RemoveAt(1);
            parts.RemoveAt(1);
        }

        return long.Parse(parts[0]);
    }

    private static long CalcWithAdditionPrecedence(string s)
    {
        var parts = s.Split(' ').ToList();

        while (parts.Contains(Addition))
        {
            var nextAdditionOperator = parts.IndexOf(Addition);
            var first = long.Parse(parts[nextAdditionOperator - 1]);
            var second = long.Parse(parts[nextAdditionOperator + 1]);
            parts[nextAdditionOperator - 1] = (first + second).ToString();
            parts.RemoveAt(nextAdditionOperator);
            parts.RemoveAt(nextAdditionOperator);
        }

        while (parts.Count > 1)
        {
            var current = long.Parse(parts[0]);
            var next = long.Parse(parts[2]);
            var result = current * next;

            parts[0] = result.ToString();
            parts.RemoveAt(1);
            parts.RemoveAt(1);
        }

        return long.Parse(parts[0]);
    }
}