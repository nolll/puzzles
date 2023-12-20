using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

[Name("Aplenty")]
public class Aoc202319(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(SortParts(input));
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(CountCombinations(input));
    }

    public static int SortParts(string s)
    {
        var groups = StringReader.ReadLineGroups(s);
        var workflowList = groups.First().Select(ParseWorkflow).ToList();
        var workflows = workflowList.ToDictionary(o => o.Label, o => o);
        var parts = groups.Last().Select(ParsePart);

        var accepted = new List<Part>();
        foreach (var part in parts)
        {
            var target = "in";
            while (target != "A" && target != "R")
            {
                target = workflows[target].Rules.First(r => r.Evaluate(part)).Target;
            }
            
            if(target == "A")
                accepted.Add(part);
        }

        var sum = accepted.Sum(o => o.Fields.Values.Sum());

        return sum;
    }

    public static long CountCombinations(string str)
    {
        var groups = StringReader.ReadLineGroups(str);
        var workflowList = groups.First().Select(ParseWorkflow).ToList();
        var workflows = workflowList.ToDictionary(o => o.Label, o => o);

        var minMax = new MinMax(1, 4000, 1, 4000, 1, 4000, 1, 4000);

        //var result = GetMinMax(workflows, "in", minMax);
        //var x = result.XMax - result.XMin;
        //var m = result.MMax - result.MMin;
        //var a = result.AMax - result.AMin;
        //var s = result.SMax - result.SMin;
        //return 1L * x * m * a * s;
        return 0;
    }

    //private static MinMax GetMinMax(
    //    Dictionary<string, Workflow> workflows,
    //    string target,
    //    MinMax minMax)
    //{
    //    if (target == "A")
    //        return minMax;

    //    var workflow = workflows[target];
        
    //    foreach (var rule in workflow.Rules)
    //    {
    //        if (rule.Field == "")
    //            return (minValues, maxValues);

    //        if (rule.Target == "R")
    //            continue;

    //        //var ruleTarget = rule.Target;

    //        //if (ruleTarget != "R")
    //        //    count += CountCombinations(workflows, target, combinations / rule.MatchingCount);

    //    }
    //    return possible;
    //}

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
        var rules = parts.Last().Split(',').Select(ParseRule).ToList();
        return new Workflow(label, rules);
    }

    private static WorkflowRule ParseRule(string s)
    {
        var parts = s.Split(':');
        var target = parts.Last();
        var hasRule = parts.Length > 1;
        var field = hasRule ? parts[0][..1] : "";
        var comparison = hasRule ? parts[0].Substring(1,1) : "";
        var value = hasRule ? int.Parse(parts[0][2..]) : 0;

        if (hasRule)
        {
            if (comparison == "<")
                return new LessThanRule(target, field, value);
            return new GreaterThanRule(target, field, value);
        }
        
        return new NoRule(target);
    }
}

public record MinMax(int XMin, int XMax, int MMin, int MMax, int AMin, int AMax, int SMin, int SMax);

public class LessThanRule(string target, string field, int value) : WorkflowRule
{
    public override string Target { get; } = target;
    public override string Field { get; } = field;
    public override int Value { get; } = value;
    public override int MatchingCount { get; } = value - 1;
    public override bool Evaluate(Part part) => part.Fields[field] < value;
}

public class GreaterThanRule(string target, string field, int value) : WorkflowRule
{
    public override string Target { get; } = target;
    public override string Field { get; } = field;
    public override int Value { get; } = value;
    public override int MatchingCount { get; } = 4000 - value;
    public override bool Evaluate(Part part) => part.Fields[field] > value;
}

public class NoRule(string target) : WorkflowRule
{
    public override string Target { get; } = target;
    public override string Field { get; } = "";
    public override int Value { get; } = 0;
    public override int MatchingCount { get; } = 4000;
    public override bool Evaluate(Part part) => true;
}

public abstract class WorkflowRule
{
    public abstract string Target { get; }
    public abstract string Field { get; }
    public abstract int Value { get; }
    public abstract int MatchingCount { get; }
    public abstract bool Evaluate(Part part);
}

public class Workflow(string label, List<WorkflowRule> rules)
{
    public string Label { get; } = label;
    public List<WorkflowRule> Rules { get; } = rules;
}

public class Part(Dictionary<string, int> fields)
{
    public Dictionary<string, int> Fields { get; } = fields;
}