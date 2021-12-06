using Core.Common.CoordinateSystems;

namespace ConsoleApp.Puzzles.Year2018.Day15
{
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
}