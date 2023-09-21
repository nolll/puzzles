using System;
using System.Collections.Generic;

namespace Aoc.Puzzles.Year2022.Day21;

public class EqualityMonkey : MathMonkey
{
    public EqualityMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName)
        : base(monkeys, aName, bName)
    {
    }

    public override long Yell(int level)
    {
        var aYell = A.Yell(level + 1);
        var bYell = B.Yell(level + 1);
        return Math.Abs(aYell) - Math.Abs(bYell);
    }
}