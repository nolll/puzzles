using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202405;

[Name("")]
public class Aoc202405 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var rules = parts[0].Split(LineBreaks.Single).Select(o => o.Split('|').Select(int.Parse).ToArray()).ToArray();
        var updates = parts[1].Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToArray();

        var correct = new List<int[]>();
        var failed = new List<int>();
        foreach (var update in updates)
        {
            var isCorrect = IsCorrect(rules, update);
            
            if(isCorrect)
            {
                correct.Add(update);
            }
        }

        var result = correct.Sum(o => o[o.Length / 2]);
        
        return new PuzzleResult(result, "52e320d42cefb1f61089609c0f8bbf25");
    }

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var rules = parts[0].Split(LineBreaks.Single).Select(o => o.Split('|').Select(int.Parse).ToArray()).ToArray();
        var updates = parts[1].Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToArray();

        var correct = new List<int[]>();
        var failed = new List<int>();
        foreach (var update in updates)
        {
            if (IsCorrect(rules, update))
                continue;
            
            while (!IsCorrect(rules, update))
            {
                Fix(rules, update);
            }
            
            correct.Add(update);
        }

        var result = correct.Sum(o => o[o.Length / 2]);
        
        return new PuzzleResult(result, "4e2cd8cd0086290e712bf6f5f8799fe3");
    }

    private bool IsCorrect(int[][] rules, int[] update)
    {
        foreach (var rule in rules)
        {
            if (update.Contains(rule[0]) && update.Contains(rule[1]))
            {
                var leftRule = rule[0];
                var rightRule = rule[1];
                var leftPos = Array.IndexOf(update, leftRule);
                var rightPos = Array.IndexOf(update, rightRule);

                if (rightPos < leftPos)
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    private int[] Fix(int[][] rules, int[] update)
    {
        foreach (var rule in rules)
        {
            if (update.Contains(rule[0]) && update.Contains(rule[1]))
            {
                var leftRule = rule[0];
                var rightRule = rule[1];
                var leftPos = Array.IndexOf(update, leftRule);
                var rightPos = Array.IndexOf(update, rightRule);
                
                if (rightPos < leftPos)
                {
                    update[leftPos] = rightRule;
                    update[rightPos] = leftRule;
                }
            }
        }

        return update;
    }
}