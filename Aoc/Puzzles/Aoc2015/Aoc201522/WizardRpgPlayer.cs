namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public class WizardRpgPlayer(int mana, int points, int damage) : WizardRpgCharacter(points, damage)
{
    public int Mana { get; set; } = mana;
}