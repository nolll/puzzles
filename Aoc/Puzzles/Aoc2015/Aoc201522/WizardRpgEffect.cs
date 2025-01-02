namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public class WizardRpgEffect(string name, int damage, int armor, int healing, int recharge, int timer)
{
    public string Name { get; } = name;
    public int Damage { get; } = damage;
    public int Armor { get; } = armor;
    public int Healing { get; } = healing;
    public int Recharge { get; } = recharge;
    public int Timer { get; set; } = timer;
}