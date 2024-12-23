namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public abstract class WizardRpgCharacter
{
    public int Points { get; set; }
    public int Damage { get; }

    public bool IsAlive => Points > 0;

    protected WizardRpgCharacter(in int points, in int damage)
    {
        Points = points;
        Damage = damage;
    }
}