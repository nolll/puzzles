using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

[Name("Aplenty")]
public class Aoc202319(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(SortParts(input), "7b8de33db969cb470b0df2112b952250");
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(CountCombinations(input), "ad71ffd5c3aaba62bb775dfc6a95358e");
    }

    public static int SortParts(string s)
    {
        var groups = StringReader.ReadLineGroups(s);
        var workflowList = groups.First().Select(ParseWorkflow).ToList();
        var workflows = workflowList.ToDictionary(o => o.Label, o => o);
        var parts = groups.Last().Select(ParsePart);

        return parts.Where(part => IsAccepted(workflows, part, "in"))
            .Sum(o => o.Fields.Values.Sum());
    }

    private static bool IsAccepted(Dictionary<string, Workflow> workflows, Part part, string target)
    {
        if (target == "A")
            return true;

        if (target == "R")
            return false;

        var workflow = workflows[target];
        foreach (var rule in workflow.Rules)
        {
            if (rule.Evaluate(part))
                return IsAccepted(workflows, part, rule.Target);
        }

        return IsAccepted(workflows, part, workflow.Fallback);
    }

    public static long CountCombinations(string str)
    {
        var groups = StringReader.ReadLineGroups(str);
        var workflowList = groups.First().Select(ParseWorkflow).ToList();
        var workflows = workflowList.ToDictionary(o => o.Label, o => o);

        var ranges = new ValidValues();

        var count = CountAcceptedValues(workflows, "in", ranges);
        return count;
    }

    private static long CountAcceptedValues(
        Dictionary<string, Workflow> workflows,
        string target,
        ValidValues validValues)
    {
        if (target == "R")
            return 0;

        if (target == "A")
            return validValues.Count;

        var currentValues = validValues;
        var workflow = workflows[target];
    
        var total = 0L;
        var moreToProcess = true;

        foreach (var rule in workflow.Rules)
        {
            var includedValues = rule.Include(currentValues);
            var excludedValues = rule.Exclude(currentValues);

            if(includedValues.Count > 0)
                total += CountAcceptedValues(workflows, rule.Target, includedValues);

            if (excludedValues.Count == 0)
            {
                moreToProcess = false;
                break;
            }

            currentValues = excludedValues;
        }

        if(moreToProcess)
            total += CountAcceptedValues(workflows, workflow.Fallback, currentValues);

        return total;
    }

    private static Part ParsePart(string inp)
    {
        var parts = inp.TrimStart('{').TrimEnd('}').Split(',').ToArray();
        var fields = new Dictionary<string, int>();
        for (var i = 0; i < 4; i++)
        {
            var label = parts[i][..1];
            var value = int.Parse(parts[i][2..]);
            fields.Add(label, value);
        }
        
        return new Part(fields);
    }

    private static Workflow ParseWorkflow(string s)
    {
        var parts = s.TrimEnd('}').Split('{');
        var label = parts.First();
        var ruleParts = parts.Last().Split(',');
        var rules = ruleParts.SkipLast(1).Select(ParseRule).ToList();
        var fallback = ruleParts.Last();
        return new Workflow(label, rules, fallback);
    }

    private static WorkflowRule ParseRule(string s)
    {
        var parts = s.Split(':');
        var target = parts.Last();
        var field = parts[0][..1];
        var comparison = parts[0].Substring(1, 1);
        var value = int.Parse(parts[0][2..]);

        return comparison == "<" 
            ? new LessThanRule(target, field, value) 
            : new GreaterThanRule(target, field, value);
    }
}