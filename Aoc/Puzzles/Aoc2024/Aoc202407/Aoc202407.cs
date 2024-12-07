using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202407;

[Name("Bridge Repair")]
public class Aoc202407 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sum = ParseNumbers(input)
            .Where(row => IsValid(row, [Add, Multiply]))
            .Sum(o => o.target);
        
        return new PuzzleResult(sum, "d8627e3b777340dd66a65a22e6ea7e85");
    }

    public PuzzleResult Part2(string input)
    {
        var sum = ParseNumbers(input)
            .Where(row => IsValid(row, [Add, Multiply, Concat]))
            .Sum(o => o.target);
        
        return new PuzzleResult(sum, "caf0656b286d7fb0cfa38222a516fc08");
    }
    
    private static bool IsValid((long target, long[] units) row, Func<long, long, long>[] evaluationFuncs)
    {
        var (target, units) = row;
        var combinations = GetCombinations(units.Skip(1).ToList(), units.First(), evaluationFuncs);
        return combinations.Any(o => o == target);
    }
    
    private static IEnumerable<long> GetCombinations(List<long> units, long v, Func<long, long, long>[] evaluationFuncs)
    {
        if (units.Count == 0)
            return [v];

        var nextList = units.Skip(1).ToList();
        var nextItem = units.First();
        var results = new List<long>();
        foreach (var func in evaluationFuncs)
        {
            results.AddRange(GetCombinations(nextList, func(v, nextItem), evaluationFuncs));
        }

        return results;
    }

    private static long Add(long a, long b) => a + b;
    private static long Multiply(long a, long b) => a * b;
    private static long Concat(long a, long b) => long.Parse($"{a}{b}");

    private static (long target, long[] units)[] ParseNumbers(string input)
    {
        var list = new List<(long, long[])>();
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var target = long.Parse(parts[0]);
            var units = parts[1].Split(' ').Select(long.Parse).ToArray();
            list.Add((target, units));
        }

        return list.ToArray();
    }
}