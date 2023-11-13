using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202016;

public class TicketValidator
{
    public long GetErrorRate(string input)
    {
        var data = ParseData(input);
        var invalidValues = FindInvalidValues(data);

        return invalidValues.Sum();
    }

    private static List<int> FindInvalidValues(Data data)
    {
        var invalidValues = new List<int>();

        foreach (var ticket in data.OtherTickets)
        {
            foreach (var num in ticket.Numbers)
            {
                if (!data.Rules.Values.Any(o => o.IsValid(num)))
                {
                    invalidValues.Add(num);
                }
            }
        }

        return invalidValues;
    }

    public long CalculateAnswer(string input)
    {
        var ticket = FindFields(input);
        long product = 1;
        foreach (var field in ticket.Fields)
        {
            if (field.Key.StartsWith("departure"))
            {
                product *= field.Value;
            }
        }

        return product;
    }

    public static Ticket FindFields(string input)
    {
        var data = ParseData(input);
        var otherTickets = FilterValidTickets(data.OtherTickets, FindInvalidValues(data)).ToList();

        var possiblePositions = new Dictionary<string, List<int>>();

        foreach (var rule in data.Rules.Values)
        {
            for (var pos = 0; pos < data.MyTicket.Numbers.Count; pos++)
            {
                var currentPos = pos;
                var ticketValuesAtThisPosition = otherTickets.Select(o => o.Numbers[currentPos]);
                var isPossibleAtThisPosition = ticketValuesAtThisPosition.All(o => rule.IsValid(o));

                if (!isPossibleAtThisPosition)
                    continue;

                if (!possiblePositions.ContainsKey(rule.Name))
                    possiblePositions.Add(rule.Name, new List<int>());

                possiblePositions[rule.Name].Add(pos);
            }
        }

        var donePositions = new Dictionary<string, int>();
            
        while (possiblePositions.Any())
        {
            var nextDone = possiblePositions.First(o => o.Value.Count == 1);
            var doneValue = nextDone.Value.First();
            donePositions.Add(nextDone.Key, doneValue);
            possiblePositions.Remove(nextDone.Key);

            foreach (var key in possiblePositions.Keys)
            {
                possiblePositions[key] = possiblePositions[key].Where(o => o != doneValue).ToList();
            }
        }

        data.MyTicket.SetFields(donePositions);

        return data.MyTicket;
    }

    private static IEnumerable<Ticket> FilterValidTickets(IEnumerable<Ticket> tickets, ICollection<int> invalidValues)
    {
        return tickets.Where(ticket => !ticket.Numbers.Any(invalidValues.Contains)).ToList();
    }

    private static Data ParseData(string input)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var ruleRows = groups[0];
        var rules = ruleRows.Select(Rule.Parse).ToDictionary(rule => rule.Name);
        var myTicket = Ticket.Parse(groups[1][1]);
        var otherTickets = groups[2].Skip(1).Select(Ticket.Parse).ToList();

        return new Data(rules, myTicket, otherTickets);
    }

    private class Data
    {
        public Dictionary<string, Rule> Rules { get; }
        public Ticket MyTicket { get; }
        public List<Ticket> OtherTickets { get; }

        public Data(Dictionary<string, Rule> rules, Ticket myTicket, List<Ticket> otherTickets)
        {
            Rules = rules;
            MyTicket = myTicket;
            OtherTickets = otherTickets;
        }
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
            return num >= _from && num <= _to;
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

    public class Ticket
    {
        public Dictionary<string, int> Fields { get; }
        public List<int> Numbers { get; }

        private Ticket(List<int> numbers)
        {
            Numbers = numbers;
            Fields = new Dictionary<string, int>();
        }

        public void SetFields(Dictionary<string, int> fieldPositions)
        {
            foreach (var field in fieldPositions)
            {
                Fields[field.Key] = Numbers[field.Value];
            }
        }

        public static Ticket Parse(string s)
        {
            return new Ticket(s.Split(',').Select(int.Parse).ToList());
        }
    }
}