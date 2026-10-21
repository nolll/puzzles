using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Monkey in the Middle")]
public class Aoc202211 : AocPuzzle
{
    [Puzzle("7d4be1aa43422b2344a6125943e730c4")]
    public long Part1(string input) => Solve(input, false);

    [Puzzle("9b6edc59f2fbcf1491af28eecdb326fb")]
    public long Part2(string input) => Solve(input, true);
    
    private static long Solve(string input, bool isReallyWorried)
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

    private static Monkey[] ParseMonkeys(string input) => [.. input.Split(LineBreaks.Double).Select(ParseMonkey)];

    private static Monkey ParseMonkey(string s)
    {
        var (_, i, o, d, tt, ft) = s.Split(LineBreaks.Single);
        return new Monkey(ParseItems(i), ParseOperation(o), ParseDivisor(d), ParseTarget(tt), ParseTarget(ft));
    }

    private static List<long> ParseItems(string line) =>
        [.. line.Split(':').Last().Split(',').Select(long.Parse)];

    private static MonkeyOperation ParseOperation(string s)
    {
        var (_, op, right) = s.Split('=').Last().Trim().Split();
        return new MonkeyOperation(op, right);
    }

    private static long ParseDivisor(string s) => long.Parse(ParseValue(s));
    private static int ParseTarget(string s) => int.Parse(ParseValue(s));
    private static string ParseValue(string s) => s.Split(' ').Last();
}

public record MonkeyOperation(string Op, string Right);

public class Monkey(IList<long> items, MonkeyOperation operation, long divisor, int trueTarget, int falseTarget)
{
    public IList<long> Items { get; } = items;
    private MonkeyOperation Operation { get; } = operation;
    public long Divisor { get; } = divisor;
    public int TrueTarget { get; } = trueTarget;
    public int FalseTarget { get; } = falseTarget;
    public long Level { get; set; }

    public long Calc(long val)
    {
        var right = Operation.Right == "old" ? val : long.Parse(Operation.Right);
        return Operation.Op == "+" ? val + right : val * right;
    }
}