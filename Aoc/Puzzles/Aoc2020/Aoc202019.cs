using System.Text;
using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Monster Messages")]
public class Aoc202019 : AocPuzzle
{
    [Puzzle("5689e3eed11a233bb204f8f0e2bfe42f")]
    public int Part1(string input)
    {
        var (rules, messages) = Init(input);
        return ValidCount(rules, messages);
    }

    [Puzzle("95d28bbc9dd67fbc8d8db74ab2879177")]
    public int Part2(string input)
    {
        var (rules, messages) = Init(input);
        rules = ModifyRules(rules);
        return ValidCount(rules, messages);
    }

    private (Dictionary<int, Rule> rules, List<string> messages) Init(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();
        var ruleStrings = groups[0];
        var messages = groups.Count > 1 ? groups[1] : [];
        var rules = ParseRules(ruleStrings);
        
        return (rules, messages);
    }

    public Dictionary<int, Rule> ModifyRules(Dictionary<int, Rule> rules)
    {
        rules[8] = new Rule8(rules);
        rules[11] = new Rule11(rules);
        return rules;
    }

    private class Rule8(Dictionary<int, Rule> allRules) : RecursiveRule(8, RuleSets, allRules)
    {
        private static IList<IList<int>> RuleSets =>
        [
            [42],
            [42, 8]
        ];
    }

    private class Rule11(Dictionary<int, Rule> allRules) : RecursiveRule(11, RuleSets, allRules)
    {
        private static IList<IList<int>> RuleSets =>
        [
            [42, 31],
            [42, 11, 31]
        ];
    }

    public Dictionary<int, Rule> ParseRules(List<string> ruleStrings)
    {
        var rules = new Dictionary<int, Rule>();

        while (ruleStrings.Count != 0)
        {
            var s = ruleStrings.First();
            var rule = Rule.Parse(s, rules);
            rules.Add(rule.Id, rule);
            ruleStrings.RemoveAt(0);
        }

        return rules;
    }

    public int ValidCount(Dictionary<int, Rule> rules, IList<string> messages)
    {
        var regex = BuildRegex(rules);
        return messages.Count(o => IsValid(o, regex));
    }

    public bool IsValid(Dictionary<int, Rule> rules, string message) => BuildRegex(rules).IsMatch(message);
    private bool IsValid(string message, Regex regex) => regex.IsMatch(message);
    private Regex BuildRegex(Dictionary<int, Rule> rules) => BuildRegex(rules[0]);
    private Regex BuildRegex(Rule rule) => new($"^{rule.GetRegexPattern()}$");

    public abstract class Rule(int id)
    {
        public int Id { get; } = id;

        public abstract string GetRegexPattern();
        public int UseCount { get; set; }

        public static Rule Parse(string s, Dictionary<int, Rule> rules)
        {
            var parts = s.Split(':');
            var id = int.Parse(parts[0]);
            var rule = parts[1].Trim();
            if (rule.StartsWith('"'))
            {
                var c = rule.Replace("\"", "").ToCharArray().First();
                return new BasicRule(id, c);
            }

            var a = rule.Split('|').ToList();
            var b = a.Select(o => o.Trim().Split(' ')).ToList();
            var ints = b.Select(o => o.Select(int.Parse)).ToList();
            var ruleIds = ints.Select(i => i.ToList()).Cast<IList<int>>().ToList();

            var compositeRule = new CompositeRule(id, ruleIds, rules);
            return compositeRule;
        }
    }

    private class RecursiveRule(int id, IList<IList<int>> ruleSets, Dictionary<int, Rule> allRules) : Rule(id)
    {
        private int _recursions;

        public override string GetRegexPattern()
        {
            _recursions++;
            if (_recursions > 5)
                return "";

            var patterns = ruleSets.Select(GetRuleSetPattern);

            if (ruleSets.Count <= 1)
                return patterns.First();
            
            var joinedPatterns = string.Join("|", patterns);
            return $"({joinedPatterns})";
        }

        private string GetRuleSetPattern(IList<int> ruleSet)
        {
            var pattern = new StringBuilder();
            foreach (var ruleId in ruleSet)
            {
                var rule = allRules[ruleId];
                rule.UseCount++;

                pattern.Append(rule.GetRegexPattern());
            }

            return pattern.ToString();
        }
    }

    private class CompositeRule(int id, IList<IList<int>> ruleSets, Dictionary<int, Rule> allRules) : Rule(id)
    {
        public override string GetRegexPattern()
        {
            var patterns = ruleSets.Select(GetRuleSetPattern);

            if (ruleSets.Count <= 1)
                return patterns.First();
            
            var joinedPatterns = string.Join("|", patterns);
            return $"({joinedPatterns})";
        }

        private string GetRuleSetPattern(IList<int> ruleSet)
        {
            var pattern = new StringBuilder();
            foreach (var ruleId in ruleSet)
            {
                var rule = allRules[ruleId];
                rule.UseCount++;

                pattern.Append(rule.GetRegexPattern());
            }

            return pattern.ToString();
        }
    }

    private class BasicRule(int id, char c) : Rule(id)
    {
        public override string GetRegexPattern() => c.ToString();
    }
}