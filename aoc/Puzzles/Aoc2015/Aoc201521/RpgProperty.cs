namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201521;

public class RpgProperty
{
    public string Name { get; }
    public int Cost { get; }
    public int Damage { get; }
    public int Armor { get; }

    public RpgProperty(string name, int cost, int damage, int armor)
    {
        Name = name;
        Cost = cost;
        Damage = damage;
        Armor = armor;
    }
}