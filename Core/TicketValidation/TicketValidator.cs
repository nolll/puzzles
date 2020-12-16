using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.TicketValidation
{
    public class TicketValidator
    {
        public long GetErrorRate(string input)
        {
            var groups = PuzzleInputReader.ReadLineGroups(input);
            var ruleRows = groups[0];
            var rules = ruleRows.Select(Rule.Parse).ToDictionary(rule => rule.Name);
            var myTicket = ParseTicket(groups[1][1]);
            var otherTickets = groups[2].Skip(1).Select(ParseTicket);
            var invalidValues = new List<int>();

            foreach (var ticket in otherTickets)
            {
                foreach (var num in ticket)
                {
                    if (!rules.Values.Any(o => o.IsValid(num)))
                    {
                        invalidValues.Add(num);
                    }
                }
            }

            return invalidValues.Sum();
        }

        private List<int> ParseTicket(string s)
        {
            return s.Split(',').Select(int.Parse).ToList();
        }

        public class Range
        {
            private readonly int _from;
            private readonly int _to;

            private Range(int from, int to)
            {
                _from = from;
                _to = to;
            }

            public bool IsInRange(int num)
            {
                if (num >= _from && num <= _to)
                    return true;
                return false;
            }

            public static Range Parse(string s)
            {
                var parts = s.Split('-');
                return new Range(int.Parse(parts[0]), int.Parse(parts[1]));
            }
        }

        public class Rule
        {
            public string Name { get; }
            private List<Range> Ranges { get; }

            private Rule(string name, List<Range> ranges)
            {
                Name = name;
                Ranges = ranges;
            }

            public bool IsValid(int num)
            {
                return Ranges.Any(o => o.IsInRange(num));
            }
            
            public static Rule Parse(string s)
            {
                var parts = s.Split(':');
                var name = parts[0];
                var rangeParts = parts[1].Trim().Split(' ');
                var ruleStrings = new List<string>
                {
                    rangeParts[0], rangeParts[2]
                };
                var ranges = ruleStrings.Select(Range.Parse).ToList();
                return new Rule(name, ranges);
            }
        }
    }
}