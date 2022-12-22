using System.Collections.Generic;

namespace Core.Puzzles.Year2022.Day21;

public class MultiplicationMonkey : MathMonkey
{
    public MultiplicationMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName)
        : base(monkeys, aName, bName)
    {
    }

    public override long Yell(int level)
    {
        return A.Yell(level + 1) * B.Yell(level + 1);
    }
}