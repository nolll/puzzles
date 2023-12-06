namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

public abstract class RpgCharacter
{
    private readonly int _armor;

    public string Name { get; }
    public int Points { get; private set; }
    public int Damage { get; }

    public bool IsAlive => Points > 0;

    protected RpgCharacter(string name, in int points, in int damage, in int armor)
    {
        Name = name;
        Points = points;
        Damage = damage;
        _armor = armor;
    }

    public bool Hurt(int attack)
    {
        Points -= Math.Max(attack - _armor, 1);
        return IsAlive;
    }
}