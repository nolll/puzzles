using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201815;

public class BattleFigure
{
    public int HitPoints { get; private set; }
    public int Id { get; }
    public char Type { get; }
    public int AttackPower { get; }
    public MatrixAddress Address { get; private set; }
    public bool IsDead => HitPoints <= 0;

    public BattleFigure(int id, char type, int attackPower, MatrixAddress address)
    {
        HitPoints = 200;
        Id = id;
        Type = type;
        AttackPower = attackPower;
        Address = address;
    }

    public void Hit(int attackPower)
    {
        HitPoints -= attackPower;
    }

    public void MoveTo(MatrixAddress address)
    {
        Address = address;
    }
}