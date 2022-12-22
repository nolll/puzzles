using System.Collections.Generic;

namespace Core.Puzzles.Year2022.Day21;

public class NumberMonkey : YellMonkey
{
    private readonly long _number;

    public NumberMonkey(Dictionary<string, YellMonkey> monkeys, long number)
        : base(monkeys)
    {
        _number = number;
    }

    public override long Yell(int level)
    {
        return _number;
    }
}