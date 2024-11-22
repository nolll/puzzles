using System.Text.RegularExpressions;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202018;

public class HomeworkCalculator
{
    private const string Addition = "+";
    private const string Multiplication = "*";
    private const char GroupStart = '(';
    private const char GroupEnd = ')';

    public long SumOfAll(string input, MathPrecedence precedence)
    {
        var rows = StringReader.ReadLines(input);
        return rows.Sum(o => Sum(o, precedence));
    }

    public long Sum(string input, MathPrecedence precedence)
    {
        var rootGroup = new Group(input, precedence);
        var result = rootGroup.Result;
        return result;
    }

    private class Group
    {
        public long Result { get; }

        public Group(string s, MathPrecedence precedence)
        {
            var calc = GetCalcFunc(precedence);
            var regex = new Regex(@"\([0-9 \*\+]+\)");
            while (s.Contains('('))
            {
                var matches = regex.Matches(s);
                foreach (Match match in matches)
                {
                    var hit = match.ToString();
                    var result = calc(hit.TrimStart(GroupStart).TrimEnd(GroupEnd));
                    s = s.Replace(hit, result.ToString());
                }
            }
                
            Result = calc(s);
        }

        private long CalcWithOrderPrecedence(string s)
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

        private long CalcWithAdditionPrecedence(string s)
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

            while (parts.Count() > 1)
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

        private Func<string, long> GetCalcFunc(MathPrecedence precedence)
        {
            if (precedence == MathPrecedence.Addition)
                return CalcWithAdditionPrecedence;
            return CalcWithOrderPrecedence;
        }
    }
}