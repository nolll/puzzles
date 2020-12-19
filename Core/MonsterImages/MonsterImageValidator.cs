using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MonsterImages
{
    public class MonsterImageValidator
    {
        private readonly IList<string> _messages;
        private readonly Dictionary<int, Rule> _rules;

        public MonsterImageValidator(string input)
        {
            var groups = PuzzleInputReader.ReadLineGroups(input);
            var ruleStrings = groups[0];
            _messages = groups[1];
            _rules = ParseRules(ruleStrings);
        }

        private Dictionary<int, Rule> ParseRules(IList<string> ruleStrings)
        {
            var rules = new Dictionary<int, Rule>();

            while (ruleStrings.Any())
            {
                var s = ruleStrings.First();
                var parts = s.Split(':');
                var number = int.Parse(parts[0]);
                var rule = parts[1].Trim();
                if (rule.StartsWith('"'))
                {
                    var c = rule.Replace("\"", "").ToCharArray().First();
                    rules.Add(number, new BasicRule(c));
                }
                else
                {
                    var a = rule.Split('|').ToList();
                    var b = a.Select(o => o.Trim().Split(' ')).ToList();
                    var ints = b.Select(o => o.Select(int.Parse)).ToList();
                    var ruleList = new List<IList<Rule>>();
                    foreach (var i in ints)
                    {
                        var innerList = new List<Rule>();
                        foreach (var inner in i)
                        {
                            if (rules.TryGetValue(inner, out var r))
                                innerList.Add(r);
                            else
                                innerList.Add(null);
                        }
                        ruleList.Add(innerList);
                    }

                    if (ruleList.All(o => o.All(p => p != null)))
                    {
                        var compositeRule = new CompositeRule(ruleList);
                        rules.Add(number, compositeRule);
                    }
                    else
                    {
                        ruleStrings.Add(s);
                    }
                }

                ruleStrings.RemoveAt(0);
            }

            return rules;
        }

        public int ValidCount()
        {
            var rule = _rules[0];
            var validCount = 0;
            foreach (var message in _messages)
            {
                var v = rule.MatchingLetters(message);
                if(v != null && v.Value == message.Length)
                    validCount++;
            }

            return validCount;
        }

        public abstract class Rule
        {
            public abstract int? MatchingLetters(string s);
        }

        public class CompositeRule : Rule
        {
            private readonly IList<IList<Rule>> _rules;

            public CompositeRule(IList<IList<Rule>> rules)
            {
                _rules = rules;
            }

            public override int? MatchingLetters(string s)
            {
                foreach (var ruleList in _rules)
                {
                    var matchingLetters = 0;
                    var ruleCount = ruleList.Count;
                    var validRules = 0;
                    foreach (var rule in ruleList)
                    {
                        var stringToSearch = s.Substring(matchingLetters);
                        var m = rule.MatchingLetters(stringToSearch);
                        if (m == null)
                            continue;

                        validRules++;
                        matchingLetters += m.Value;
                    }

                    if (validRules == ruleCount)
                        return matchingLetters;
                }

                return null;
            }
        }

        public class BasicRule : Rule
        {
            private readonly char _c;

            public BasicRule(char c)
            {
                _c = c;
            }

            public override int? MatchingLetters(string s)
            {
                if (s.First() == _c)
                    return 1;
                return null;
            }
        }
    }
}