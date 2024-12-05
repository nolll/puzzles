using Pzl.Common;
using Pzl.Tools.Strings;
using Pzl.Tools.Lists;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202405;

[Name("Print Queue")]
public class Aoc202405 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (rules, updates) = ParseRulesAndUpdates(input);
        var result = updates.Where(o => IsCorrect(rules, o))
            .Sum(GetMiddleValue);
        
        return new PuzzleResult(result, "52e320d42cefb1f61089609c0f8bbf25");
    }

    public PuzzleResult Part2(string input)
    {
        var (rules, updates) = ParseRulesAndUpdates(input);
        var result = updates.Where(o => !IsCorrect(rules, o))
            .Select(o => Fix(rules, o))
            .Sum(GetMiddleValue);
        
        return new PuzzleResult(result, "4e2cd8cd0086290e712bf6f5f8799fe3");
    }
    
    private static (int[][] rules, int[][] updates) ParseRulesAndUpdates(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var rules = parts[0].Split(LineBreaks.Single).Select(o => o.Split('|').Select(int.Parse).ToArray()).ToArray();
        var updates = parts[1].Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToArray();
        return (rules, updates);
    }

    private static bool IsCorrect(int[][] rules, int[] update) => 
        rules.All(rule => !IsAffectedByRule(update, rule) || IsInCorrectOrder(update, rule));

    private static int[] Fix(int[][] rules, int[] update)
    {
        var copy = update.ToArray();
        while (!IsCorrect(rules, copy))
        {
            copy = ApplyRules(rules, copy);
        }

        return copy;
    }

    private static int[] ApplyRules(int[][] rules, int[] update)
    {
        var copy = update.ToArray();
        foreach (var rule in rules)
        {
            if (!IsAffectedByRule(copy, rule) || IsInCorrectOrder(copy, rule)) 
                continue;
            
            copy[copy.IndexOf(rule[0])] = rule[1];
            copy[copy.IndexOf(rule[1])] = rule[0];
        }

        return copy;
    }
    
    private static bool IsAffectedByRule(int[] update, int[] rule) => 
        update.Contains(rule[0]) && update.Contains(rule[1]);

    private static bool IsInCorrectOrder(int[] update, int[] rule) => 
        update.IndexOf(rule[1]) > update.IndexOf(rule[0]);
    
    private static int GetMiddleValue(int[] o) => o[o.Length / 2];
}
