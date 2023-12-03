namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202221;

public class DivisionMonkey : MathMonkey
{
    public DivisionMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName)
        : base(monkeys, aName, bName)
    {
    }

    public override long Yell(int level)
    {
        return A!.Yell(level + 1) / B!.Yell(level + 1);
    }
}