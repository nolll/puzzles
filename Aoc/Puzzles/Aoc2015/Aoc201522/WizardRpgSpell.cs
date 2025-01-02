namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public class WizardRpgSpell(string name, int cost, int damage, int armor, int healing, int recharge, int timer)
{
    public string Name { get; } = name;
    public int Cost { get; } = cost;

    public WizardRpgEffect GetEffect() => new(Name, damage, armor, healing, recharge, timer);
}