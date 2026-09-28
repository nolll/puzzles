using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Monkey in the Middle")]
public class Aoc202211 : AocPuzzle
{
    [Puzzle("7d4be1aa43422b2344a6125943e730c4")]
    public long Part1(string input) => new MonkeyBusiness().Part1(input);

    [Puzzle("9b6edc59f2fbcf1491af28eecdb326fb")]
    public long Part2(string input) => new MonkeyBusiness().Part2(input);

    public class MonkeyBusiness
    {
        public long Part1(string input) => Run(input, false);
        public long Part2(string input) => Run(input, true);

        private long Run(string input, bool isReallyWorried)
        {
            var monkeys = ParseMonkeys(input);
            var rounds = isReallyWorried ? 10_000 : 20;
            var divisors = monkeys.Select(o => o.Divisor);
            var commonDivisor = divisors.Aggregate<long, long>(1, (c, d) => c * d);

            for (var i = 0; i < rounds; i++)
            {
                foreach (var monkey in monkeys)
                {
                    var items = monkey.Items.ToList();
                    monkey.Items.Clear();

                    foreach (var item in items)
                    {
                        monkey.Level++;
                        var worryLevel = isReallyWorried
                            ? monkey.Calc(item) % commonDivisor
                            : monkey.Calc(item) / 3;
                        var result = worryLevel % monkey.Divisor == 0;
                        var target = result ? monkey.TrueTarget : monkey.FalseTarget;
                        var targetMonkey = monkeys[target];
                        targetMonkey.Items.Add(worryLevel);
                    }
                }
            }

            var itemLevels = monkeys.Select(o => o.Level);
            var topLevels = itemLevels.OrderDescending().Take(2).ToList();
            return topLevels[0] * topLevels[1];
        }

        private static Monkey[] ParseMonkeys(string input) => input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .Select(ParseMonkey)
            .ToArray();

        private static Monkey ParseMonkey(List<string> group)
        {
            var items = ParseItems(group[1]);
            var operation = ParseOperation(group[2]);
            var divisor = ParseDivisor(group[3]);
            var trueTarget = ParseTarget(group[4]);
            var falseTarget = ParseTarget(group[5]);

            return new Monkey(items, operation, divisor, trueTarget, falseTarget);
        }

        private static List<long> ParseItems(string line) =>
            line.Trim().Split(':').Last().Trim().Split(',').Select(o => long.Parse(o.Trim())).ToList();

        private static MonkeyOperation ParseOperation(string s)
        {
            var parts = s.Trim().Split('=').Last().Trim().Split();
            var op = parts[1];
            var right = parts[2];
            return new MonkeyOperation(op, right);
        }

        private static long ParseDivisor(string s)
        {
            var parts = s.Trim().Split(' ');
            return long.Parse(parts.Last());
        }

        private static int ParseTarget(string s)
        {
            var parts = s.Trim().Split(' ');
            return int.Parse(parts.Last());
        }
    }
    
    public class MonkeyOperation
    {
        public string Op { get; }
        public string Right { get; }

        public MonkeyOperation(string op, string right)
        {
            Op = op;
            Right = right;
        }
    }
    
    public class Monkey
    {
        public IList<long> Items { get; }
        public MonkeyOperation Operation { get; }
        public long Divisor { get; }
        public int TrueTarget { get; }
        public int FalseTarget { get; }
        public long Level { get; set; }

        public Monkey(IList<long> items, MonkeyOperation operation, long divisor, int trueTarget, int falseTarget)
        {
            Items = items;
            Operation = operation;
            Divisor = divisor;
            TrueTarget = trueTarget;
            FalseTarget = falseTarget;
            Level = 0;
        }

        public long Calc(long val)
        {
            var right = Operation.Right == "old" ? val : long.Parse(Operation.Right);
            if (Operation.Op == "+")
                return val + right;
            return val * right;
        }
    }
}