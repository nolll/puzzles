using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Ticket Translation")]
public class Aoc202016 : AocPuzzle
{
    [Puzzle("7d78cfbc759526833a4566918a854e5b")]
    public long Part1(string input) => FindInvalidValues(ParseData(input)).Sum();

    [Puzzle("f42f08ba29065a89fd379a7eceb34b50")]
    public long Part2(string input) => CalculateAnswer(input);

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

    private static long CalculateAnswer(string input) =>
        FindFields(input).Fields.Where(field => field.Key.StartsWith("departure"))
            .Aggregate<KeyValuePair<string, int>, long>(1, (current, field) => current * field.Value);

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

        while (possiblePositions.Count != 0)
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

    private static IEnumerable<Ticket> FilterValidTickets(IEnumerable<Ticket> tickets, ICollection<int> invalidValues) => 
        tickets.Where(ticket => !ticket.Numbers.Any(invalidValues.Contains)).ToList();

    private static Data ParseData(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();
        var ruleRows = groups[0];
        var rules = ruleRows.Select(Rule.Parse).ToDictionary(rule => rule.Name);
        var myTicket = Ticket.Parse(groups[1][1]);
        var otherTickets = groups[2].Skip(1).Select(Ticket.Parse).ToList();

        return new Data(rules, myTicket, otherTickets);
    }

    private record Data(Dictionary<string, Rule> Rules, Ticket MyTicket, List<Ticket> OtherTickets);

    public class Range(int from, int to)
    {
        public bool IsInRange(int num) => num >= from && num <= to;

        public static Range Parse(string s)
        {
            var parts = s.Split('-');
            return new Range(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }

    public record Rule(string Name, List<Range> Ranges)
    {
        public bool IsValid(int num) => Ranges.Any(o => o.IsInRange(num));

        public static Rule Parse(string s)
        {
            var parts = s.Split(':');
            var name = parts[0];
            var rangeParts = parts[1].Trim().Split(' '); 
            List<string> ruleStrings =
            [
                rangeParts[0], rangeParts[2]
            ];
            var ranges = ruleStrings.Select(Range.Parse).ToList();
            return new Rule(name, ranges);
        }
    }

    public record Ticket(List<int> Numbers)
    {
        public Dictionary<string, int> Fields { get; } = new();

        public void SetFields(Dictionary<string, int> fieldPositions)
        {
            foreach (var field in fieldPositions)
            {
                Fields[field.Key] = Numbers[field.Value];
            }
        }

        public static Ticket Parse(string s) => new(s.Split(',').Select(int.Parse).ToList());
    }
}