namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201521;

public class RpgPlayer : RpgCharacter
{
    public RpgPlayer(int points, int damage, int armor)
        : base("player", points, damage, armor)
    {
    }

    public RpgPlayer(int points, IList<RpgProperty> properties)
        : base("player", points, properties.Sum(o => o.Damage), properties.Sum(o => o.Armor))
    {
    }
}