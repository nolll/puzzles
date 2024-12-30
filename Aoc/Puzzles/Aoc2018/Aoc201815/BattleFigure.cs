using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

public class BattleFigure(char type, int attackPower, MatrixAddress address)
{
    public int HitPoints { get; private set; } = 200;
    public char Type { get; } = type;
    public int AttackPower { get; } = attackPower;
    public MatrixAddress Address { get; private set; } = address;
    public bool IsDead => HitPoints <= 0;

    public void Hit(int attackPower) => HitPoints -= attackPower;
    public void MoveTo(MatrixAddress address) => Address = address;
}