using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day11;

public class MonkeyBusiness
{
    public long Run(string input, bool adjustWorryLevel, int rounds)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var monkeys = new Dictionary<int, Monkey>();

        foreach (var group in groups)
        {
            var line1Parts = group[0].Trim().Replace(":", "").Split(' ');
            var id = int.Parse(line1Parts[1]);

            var line2Parts = group[1].Trim().Split(':');
            var items = line2Parts[1].Trim().Split(',').Select(o => long.Parse(o.Trim())).ToList();

            var line3Parts = group[2].Trim().Split('=');
            var operationParts = line3Parts[1].Trim().Split();
            var op = operationParts[1];
            var right = operationParts[2];
            var operation = new MonkeyOperation(op, right);

            var line4Parts = group[3].Trim().Split(' ');
            var divisor = long.Parse(line4Parts[3]);

            var line5Parts = group[4].Trim().Split(' ');
            var trueTarget = int.Parse(line5Parts[5]);

            var line6Parts = group[5].Trim().Split(' ');
            var falseTarget = int.Parse(line6Parts[5]);

            monkeys.Add(id, new Monkey(id, items, operation, divisor, trueTarget, falseTarget));
        }

        for (var i = 0; i < rounds; i++)
        {
            for (var m = 0; m < monkeys.Count; m++)
            {
                var monkey = monkeys[m];
                var items = monkey.Items.ToList();
                monkey.Items.Clear();

                foreach (var item in items)
                {
                    var worryLevel = monkey.Calc(item);
                    monkey.Level++;
                    var adjustedWorryLevel = adjustWorryLevel
                        ? worryLevel / 3
                        : worryLevel;
                    var result = adjustedWorryLevel % monkey.Divisor == 0;
                    var target = result ? monkey.TrueTarget : monkey.FalseTarget;
                    var targetMonkey = monkeys[target];

                    if(adjustWorryLevel)
                        targetMonkey.AddItemPart1(adjustedWorryLevel);
                    else
                        targetMonkey.AddItemPart2(adjustedWorryLevel);
                }
            }
        }

        var itemLevels = monkeys.Values.Select(o => o.Level);
        var topLevels = itemLevels.OrderDescending().Take(2).ToList();
        return topLevels[0] * topLevels[1];
    }
}