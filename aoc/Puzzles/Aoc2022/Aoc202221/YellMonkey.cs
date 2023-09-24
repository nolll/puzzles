using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2022.Aoc202221;

public abstract class YellMonkey
{
    protected readonly Dictionary<string, YellMonkey> Monkeys;
    public string? AName { get; set; }
    public string? BName { get; set; }
    public virtual YellMonkey? A { get; set; } = null;
    public virtual YellMonkey? B { get; set; } = null;

    protected YellMonkey(Dictionary<string, YellMonkey> monkeys)
    {
        Monkeys = monkeys;
    }

    public abstract long Yell(int level);
}