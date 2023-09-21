using System.Collections.Generic;

namespace Aoc.Puzzles.Year2022.Day21;

public abstract class YellMonkey
{
    protected readonly Dictionary<string, YellMonkey> Monkeys;
    public string AName;
    public string BName;
    public virtual YellMonkey A { get; set; } = null;
    public virtual YellMonkey B { get; set; } = null;

    protected YellMonkey(Dictionary<string, YellMonkey> monkeys)
    {
        Monkeys = monkeys;
    }

    public abstract long Yell(int level);
}