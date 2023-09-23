using System.Collections.Generic;

namespace Aoc.Puzzles.Year2022.Day21;

public abstract class MathMonkey : YellMonkey
{
    private YellMonkey? _monkeyA;
    private YellMonkey? _monkeyB;

    public override YellMonkey? A
    {
        get => _monkeyA ??= Monkeys[AName!];
        set => _monkeyA = value;
    }

    public override YellMonkey? B
    {
        get => _monkeyB ??= Monkeys[BName!];
        set => _monkeyB = value;
    }

    protected MathMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName)
        : base(monkeys)
    {
        AName = aName;
        BName = bName;
    }
}