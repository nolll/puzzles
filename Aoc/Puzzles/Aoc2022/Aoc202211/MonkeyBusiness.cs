using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202211;

public class MonkeyBusiness
{
    public long Part1(string input)
    {
        return Run(input, false);
    }

    public long Part2(string input)
    {
        return Run(input, true);
    }

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

    private static Monkey[] ParseMonkeys(string input)
    {
        return StringReader.ReadLineGroups(input)
            .Select(ParseMonkey)
            .ToArray();
    }

    private static Monkey ParseMonkey(IList<string> group)
    {
        var items = ParseItems(group[1]);
        var operation = ParseOperation(group[2]);
        var divisor = ParseDivisor(group[3]);
        var trueTarget = ParseTarget(group[4]);
        var falseTarget = ParseTarget(group[5]);

        return new Monkey(items, operation, divisor, trueTarget, falseTarget);
    }

    private static List<long> ParseItems(string line)
    {
        return line.Trim().Split(':').Last().Trim().Split(',').Select(o => long.Parse(o.Trim())).ToList();
    }

    private static MonkeyOperation ParseOperation(string line)
    {
        var parts = line.Trim().Split('=').Last().Trim().Split();
        var op = parts[1];
        var right = parts[2];
        return new MonkeyOperation(op, right);
    }

    private static long ParseDivisor(string line)
    {
        var parts = line.Trim().Split(' ');
        return long.Parse(parts.Last());
    }

    private static int ParseTarget(string line)
    {
        var parts = line.Trim().Split(' ');
        return int.Parse(parts.Last());
    }
}