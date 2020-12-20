using System;
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
            _messages = groups.Count > 1 ? groups[1] : new List<string>();
            _rules = ParseRules(ruleStrings);
        }

        private Dictionary<int, Rule> ParseRules(IList<string> ruleStrings)
        {
            var rules = new Dictionary<int, Rule>();
            
            while (ruleStrings.Any())
            {
                var s = ruleStrings.First();
                var parts = s.Split(':');
                var id = int.Parse(parts[0]);
                var rule = parts[1].Trim();
                if (rule.StartsWith('"'))
                {
                    var c = rule.Replace("\"", "").ToCharArray().First();
                    rules.Add(id, new BasicRule(id, c));
                }
                else
                {
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
                        //innerIntList.Reverse();
                        ruleIds.Add(innerIntList);
                    }

                    //ruleIds.Reverse();
                    var compositeRule = new CompositeRule(id, ruleIds, rules);
                    rules.Add(id, compositeRule);
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
                var v = rule.MatchingLetters(message, 0);
                if(v != null && v.Value == message.Length)
                    validCount++;
            }

            return validCount;
        }

        public int? MatchingLetters(string message)
        {
            var rule = _rules[0];
            return rule.MatchingLetters(message, 0);
        }

        public abstract class Rule
        {
            public int Id { get; }

            protected Rule(int id)
            {
                Id = id;
            }

            public abstract int? MatchingLetters(string s, int level);
        }

        public class CompositeRule : Rule
        {
            private readonly IList<IList<int>> _ruleSets;
            private readonly Dictionary<int, Rule> _allRules;
            //private readonly Dictionary<string, int?> _cache;

            public CompositeRule(int id, IList<IList<int>> ruleSets, Dictionary<int, Rule> allRules)
                : base(id)
            {
                _ruleSets = ruleSets;
                _allRules = allRules;
                //_cache = new Dictionary<string, int?>();
            }

            public override int? MatchingLetters(string s, int level)
            {
                //if (_cache.TryGetValue(s, out var cached))
                //    return cached;

                foreach (var ruleSet in _ruleSets)
                {
                    var matchingLetters = 0;
                    var ruleCount = ruleSet.Count;
                    var validRules = 0;
                    foreach (var ruleId in ruleSet)
                    {
                        var stringToSearch = s.Substring(matchingLetters);
                        //Console.WriteLine(stringToSearch);
                        if (stringToSearch.Length == 0)
                            return matchingLetters;

                        var rule = _allRules[ruleId];
                        var m = rule.MatchingLetters(stringToSearch, level + 1);
                        if (m == null)
                            break;

                        validRules++;
                        matchingLetters += m.Value;
                    }

                    if (validRules == ruleCount)
                    {
                        //_cache.Add(s, matchingLetters);
                        return matchingLetters;
                    }
                }

                //_cache.Add(s, null);
                return null;
            }
        }

        public class BasicRule : Rule
        {
            private readonly char _c;

            public BasicRule(int id, char c)
                : base(id)
            {
                _c = c;
            }

            public override int? MatchingLetters(string s, int level)
            {
                if (s.Length == 0)
                    return 0;
                if (s.First() == _c)
                    return 1;
                return null;
            }
        }
    }
}