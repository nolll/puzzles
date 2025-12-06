using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202506;

[Name("Trash Compactor")]
public class Aoc202506 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, ParseProblemsPart1), "14aae46a086cd49de712be9f0e651af3");
    public PuzzleResult Part2(string input) => new(Solve(input, ParseProblemsPart2), "2454d59e49a2a8376cfe3e826b7a14f8");

    private static long Solve(string input, Func<string, List<(List<long> numbers, char op)>> parse) => 
        parse(input).Select(o => PerformOperation(o.numbers, o.op)).ToList().Sum();

    private static long PerformOperation(List<long> numbers, char op) => op == '*' ? PerformMultiply(numbers) : PerformAdd(numbers);
    private static long PerformAdd(List<long> numbers) => numbers.Sum();
    private static long PerformMultiply(List<long> numbers) => numbers.Aggregate(1L, (current, number) => current * number);

    private static List<(List<long> numbers, char op)> ParseProblemsPart1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var numberLines = lines.SkipLast(1).Select(Numbers.LongsFromString).ToArray();
        var operators = lines.Last().Split(' ').Where(o => o.Length > 0).Select(o => o[0]).ToArray();
        return operators.Select((o, i) => (numberLines.Select(line => line[i]).ToList(), t: o)).ToList();
    }
    
    private static List<(List<long> numbers, char op)> ParseProblemsPart2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var length = lines[0].Length;
        var problems = new List<(List<long> numbers, char op)>();
        var current = new List<long>();

        for (var i = length - 1; i >= 0; i--)
        {
            var index = i;
            var chars = lines.Select(o => o[index]).Where(o => o != ' ').ToList();
            var num = long.Parse(string.Join("", chars.Where(char.IsDigit)));
            current.Add(num);
            var lastChar = chars.Last();
            if (char.IsDigit(lastChar)) continue;
            problems.Add((current, lastChar));
            current = [];
            i--;
        }

        return problems;
    }
}