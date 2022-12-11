using System.Collections.Generic;
using System.Numerics;

namespace Core.Puzzles.Year2022.Day11;

public class Monkey
{
    public int Id { get; }
    public IList<long> Items { get; }
    public MonkeyOperation Operation { get; }
    public long Divisor { get; }
    public int TrueTarget { get; }
    public int FalseTarget { get; }
    public long Level { get; set; }

    public Monkey(int id, IList<long> items, MonkeyOperation operation, long divisor, int trueTarget, int falseTarget)
    {
        Id = id;
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