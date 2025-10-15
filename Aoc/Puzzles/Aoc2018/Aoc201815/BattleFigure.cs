using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

public class BattleFigure(char type, int attackPower, Coord coord)
{
    public int HitPoints { get; private set; } = 200;
    public char Type { get; } = type;
    public int AttackPower { get; } = attackPower;
    public Coord Coord { get; private set; } = coord;
    public bool IsDead => HitPoints <= 0;

    public void Hit(int attackPower) => HitPoints -= attackPower;
    public void MoveTo(Coord address) => Coord = address;
}