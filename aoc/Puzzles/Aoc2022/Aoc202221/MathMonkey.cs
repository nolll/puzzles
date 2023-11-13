namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202221;

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