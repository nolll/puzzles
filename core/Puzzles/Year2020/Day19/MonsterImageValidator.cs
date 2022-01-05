using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Common.Strings;

namespace Core.Puzzles.Year2020.Day19;

public class MonsterImageValidator
{
    private const int MaxDepth = 100;

    private readonly IList<string> _messages;
    private readonly Dictionary<int, Rule> _rules;

    public MonsterImageValidator(string input, bool useRecursiveRules = false)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var ruleStrings = groups[0];
        _messages = groups.Count > 1 ? groups[1] : new List<string>();
        _rules = ParseRules(ruleStrings);
        if (useRecursiveRules)
        {
            _rules[8] = new Rule8(_rules);
            _rules[11] = new Rule11(_rules);
        }
    }

    private class Rule8 : RecursiveRule
    {
        public Rule8(Dictionary<int, Rule> allRules)
            : base(8, RuleSets, allRules)
        {

        }

        private static IList<IList<int>> RuleSets =>
            new List<IList<int>>
            {
                new List<int>
                {
                    42
                },
                new List<int>
                {
                    42, 8
                }
            };
    }

    private class Rule11 : RecursiveRule
    {
        public Rule11(Dictionary<int, Rule> allRules)
            : base(11, RuleSets, allRules)
        {

        }

        private static IList<IList<int>> RuleSets =>
            new List<IList<int>>
            {
                new List<int>
                {
                    42, 31
                },
                new List<int>
                {
                    42, 11, 31
                }
            };
    }

    private Dictionary<int, Rule> ParseRules(IList<string> ruleStrings)
    {
        var rules = new Dictionary<int, Rule>();
            
        while (ruleStrings.Any())
        {
            var s = ruleStrings.First();
            var rule = Rule.Parse(s, rules);
            rules.Add(rule.Id, rule);
            ruleStrings.RemoveAt(0);
        }

        return rules;
    }

    public int ValidCount()
    {
        var regex = BuildRegex();
        return _messages.Count(o => IsValid(o, regex));
    }

    public bool IsValid(string message)
    {
        var regex = BuildRegex();
        var match = regex.Match(message);
        return match.Success;
    }

    private bool IsValid(string message, Regex regex)
    {
        var match = regex.Match(message);
        return match.Success;
    }

    private Regex BuildRegex()
    {
        var rule = _rules[0];
        return BuildRegex(rule);
    }

    private Regex BuildRegex(Rule rule)
    {
        var fullPattern = $"^{rule.GetRegexPattern()}$";
        return new Regex(fullPattern);
    }

    public abstract class Rule
    {
        public int Id { get; }

        protected Rule(int id)
        {
            Id = id;
        }

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
            var ruleIds = new List<IList<int>>();
            foreach (var i in ints)
            {
                var innerIntList = new List<int>();
                foreach (var inner in i)
                {
                    innerIntList.Add(inner);
                }
                ruleIds.Add(innerIntList);
            }

            var compositeRule = new CompositeRule(id, ruleIds, rules);
            return compositeRule;
        }
    }

    private class RecursiveRule : Rule
    {
        private readonly IList<IList<int>> _ruleSets;
        private readonly Dictionary<int, Rule> _allRules;
        private int _recursions;

        public RecursiveRule(int id, IList<IList<int>> ruleSets, Dictionary<int, Rule> allRules)
            : base(id)
        {
            _ruleSets = ruleSets;
            _allRules = allRules;
            _recursions = 0;
        }

        public override string GetRegexPattern()
        {
            _recursions++;
            if (_recursions > 5)
                return "";

            var patterns = _ruleSets.Select(GetRuleSetPattern);

            if (_ruleSets.Count > 1)
            {
                var joinedPatterns = string.Join("|", patterns);
                return $"({joinedPatterns})";
            }

            return patterns.First();
        }

        private string GetRuleSetPattern(IList<int> ruleSet)
        {
            var pattern = new StringBuilder();
            foreach (var ruleId in ruleSet)
            {
                var rule = _allRules[ruleId];
                rule.UseCount++;

                pattern.Append(rule.GetRegexPattern());
            }
            return pattern.ToString();
        }
    }

    private class CompositeRule : Rule
    {
        private readonly IList<IList<int>> _ruleSets;
        private readonly Dictionary<int, Rule> _allRules;

        public CompositeRule(int id, IList<IList<int>> ruleSets, Dictionary<int, Rule> allRules)
            : base(id)
        {
            _ruleSets = ruleSets;
            _allRules = allRules;
        }

        public override string GetRegexPattern()
        {
            var patterns = _ruleSets.Select(GetRuleSetPattern);

            if (_ruleSets.Count > 1)
            {
                var joinedPatterns = string.Join("|", patterns);
                return $"({joinedPatterns})";
            }

            return patterns.First();
        }

        private string GetRuleSetPattern(IList<int> ruleSet)
        {
            var pattern = new StringBuilder();
            foreach (var ruleId in ruleSet)
            {
                var rule = _allRules[ruleId];
                rule.UseCount++;

                pattern.Append(rule.GetRegexPattern());
            }
            return pattern.ToString();
        }
    }

    private class BasicRule : Rule
    {
        private readonly char _c;

        public BasicRule(int id, char c)
            : base(id)
        {
            _c = c;
        }

        public override string GetRegexPattern() => _c.ToString();
    }
}