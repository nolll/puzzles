using System.Globalization;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202309;

public class Aoc202309 : AocPuzzle
{
    public override string Name => "Mirage Maintenance";

    protected override PuzzleResult RunPart1()
    {
        var result = Part1(InputFile);
        return new PuzzleResult(result, "42abec426a1f1903197aaf0635b6a29a");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Part2(InputFile);
        return new PuzzleResult(result, "652e203bd80c5889b310a0a8efdb2301");
    }

    public static long Part1(string input)
    {
        var lines = StringReader.ReadLines(input);
        return lines.Select(FindNextNumber).Sum();
    }

    public static long Part2(string input)
    {
        var lines = StringReader.ReadLines(input);
        return lines.Select(FindPrevNumber).Sum();
    }

    public static long FindNextNumber(string input)
    {
        var numbers = input.Split(' ').Select(long.Parse).ToList();
        var lastNumber = numbers.Last();
        var steps = new List<long>();
        while (numbers.Any(o => o != 0))
        {
            List<long> diffs = [];
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                diffs.Add(numbers[i + 1] - numbers[i]);
            }

            steps.Add(diffs.Last());
            numbers = diffs;
        }

        steps.Reverse();
        var totalSteps = steps.Sum();
        return lastNumber + totalSteps;
    }

    public static long FindPrevNumber(string input)
    {
        var numbers = input.Split(' ').Select(long.Parse).ToList();
        var firstNumber = numbers.First();
        var steps = new List<long>();

        while (numbers.Any(o => o != 0))
        {
            List<long> diffs = [];
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                diffs.Add(numbers[i + 1] - numbers[i]);
            }

            steps.Add(diffs.First());
            numbers = diffs;
        }

        steps.Reverse();
        var totalSteps = steps.Aggregate(0L, (current, step) => step - current);
        return firstNumber - totalSteps;
    }
}