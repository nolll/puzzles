namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

public abstract class RpgCharacter(string name, int points, int damage, int armor)
{
    public string Name { get; } = name;
    public int Points { get; private set; } = points;
    public int Damage { get; } = damage;

    public bool IsAlive => Points > 0;

    public bool Hurt(int attack)
    {
        Points -= Math.Max(attack - armor, 1);
        return IsAlive;
    }
}