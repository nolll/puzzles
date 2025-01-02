namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public abstract class WizardRpgCharacter(int points, int damage)
{
    public int Points { get; set; } = points;
    public int Damage { get; } = damage;

    public bool IsAlive => Points > 0;
}