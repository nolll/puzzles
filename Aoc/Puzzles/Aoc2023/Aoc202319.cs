using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Aplenty")]
public class Aoc202319 : AocPuzzle
{
    [Puzzle("7b8de33db969cb470b0df2112b952250")]
    public int Part1(string input) => SortParts(input);

    [Puzzle("ad71ffd5c3aaba62bb775dfc6a95358e")]
    public long Part2(string input) => CountCombinations(input);

    public static int SortParts(string s)
    {
        var groups = s
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();
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
        var workflows = str
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .First()
            .Select(ParseWorkflow)
            .ToDictionary(o => o.Label, o => o);

        return CountAcceptedValues(workflows, "in", new ValidValues());
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

            if (includedValues.Count > 0)
                total += CountAcceptedValues(workflows, rule.Target, includedValues);

            if (excludedValues.Count == 0)
            {
                moreToProcess = false;
                break;
            }

            currentValues = excludedValues;
        }

        if (moreToProcess)
            total += CountAcceptedValues(workflows, workflow.Fallback, currentValues);

        return total;
    }

    private static Part ParsePart(string inp)
    {
        var parts = inp.TrimStart('{').TrimEnd('}').Split(',');
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

    private class GreaterThanRule(string target, string field, int value) : WorkflowRule
    {
        public override string Target { get; } = target;
        protected override string Field { get; } = field;
        public override bool Evaluate(Part part) => Evaluate(part.Fields[Field]);
        protected override bool Evaluate(int v) => v > value;
    }

    private class LessThanRule(string target, string field, int value) : WorkflowRule
    {
        public override string Target { get; } = target;
        protected override string Field { get; } = field;
        public override bool Evaluate(Part part) => Evaluate(part.Fields[Field]);
        protected override bool Evaluate(int v) => v < value;
    }

    private class Part(Dictionary<string, int> fields)
    {
        public Dictionary<string, int> Fields { get; } = fields;
    }

    public class ValidValues
    {
        private const int RangeStart = 1;
        private const int RangeEnd = 4000;
        private readonly string[] _letters = ["x", "m", "a", "s"];

        public Dictionary<string, List<int>> Ranges { get; }

        public ValidValues()
        {
            Ranges = _letters.ToDictionary(k => k, _ => FillRange());
        }

        public ValidValues(ValidValues validValues)
        {
            Ranges = _letters.ToDictionary(k => k, v => validValues.Ranges[v]);
        }

        public long Count => Ranges.Values.Select(o => o.Count).Aggregate(1L, (a, b) => a * b);

        private static List<int> FillRange() => [.. Enumerable.Range(RangeStart, RangeEnd)];
    }

    private class Workflow(string label, List<WorkflowRule> rules, string fallback)
    {
        public string Label { get; } = label;
        public List<WorkflowRule> Rules { get; } = rules;
        public string Fallback { get; } = fallback;
    }

    private abstract class WorkflowRule
    {
        public abstract string Target { get; }
        protected abstract string Field { get; }
        public abstract bool Evaluate(Part part);
        protected abstract bool Evaluate(int v);

        public ValidValues Include(ValidValues validValues)
        {
            var v = new ValidValues(validValues);
            if (Field != "")
                v.Ranges[Field] = [.. validValues.Ranges[Field].Where(Evaluate)];
            return v;
        }

        public ValidValues Exclude(ValidValues validValues)
        {
            var v = new ValidValues(validValues);
            if (Field != "")
                v.Ranges[Field] = [.. validValues.Ranges[Field].Where(o => !Evaluate(o))];
            return v;
        }
    }
}