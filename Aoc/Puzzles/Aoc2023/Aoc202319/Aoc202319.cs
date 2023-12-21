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

        var ranges = new ValidValues();

        var result = GetAcceptedValues(workflows, "in", ranges);

        var ss = result.Select(o => o.Ranges.Values.Select(p => p.Count).Aggregate(1L, (a, b) => a * b)).Sum();
        return ss;
        //var x = result.SelectMany(o => o.Ranges["x"]).Distinct().Count();
        //var m = result.SelectMany(o => o.Ranges["m"]).Distinct().Count();
        //var a = result.SelectMany(o => o.Ranges["a"]).Distinct().Count();
        //var s = result.SelectMany(o => o.Ranges["s"]).Distinct().Count();
        //return 1L * x * m * a * s;
    }

    private static List<ValidValues> GetAcceptedValues(
        Dictionary<string, Workflow> workflows,
        string target,
        ValidValues validValues)
    {
        var acceptedRanges = new List<ValidValues>();
        var workflow = workflows[target];
        var currentValues = new ValidValues(validValues);

        foreach (var rule in workflow.Rules)
        {
            if (rule.Field == "")
            {
                if (rule.Target == "A")
                {
                    acceptedRanges.Add(new ValidValues(currentValues));
                    break;
                }

                if (rule.Target == "R")
                    break;

                acceptedRanges.AddRange(GetAcceptedValues(workflows, rule.Target, new ValidValues(currentValues)));
            }
            else
            {
                var ruleValues = new ValidValues(currentValues);
                var includedValues = rule.Include(ruleValues);
                var excludedValues = rule.Exclude(ruleValues);

                if (rule.Target == "A")
                {
                    acceptedRanges.Add(includedValues);
                    currentValues = excludedValues;
                    continue;
                }

                if (rule.Target == "R")
                {
                    currentValues = excludedValues;
                    continue;
                }

                acceptedRanges.AddRange(GetAcceptedValues(workflows, rule.Target, includedValues));
                currentValues = excludedValues;
            }
        }

        return acceptedRanges;
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