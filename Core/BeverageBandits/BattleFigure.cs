using Core.Tools;

namespace Core.BeverageBandits
{
    public class BattleFigure
    {
        public int HitPoints { get; private set; }
        public int Id { get; }
        public char Type { get; }
        public MatrixAddress Address { get; private set; }
        public bool IsDead => HitPoints <= 0;

        public BattleFigure(int id, char type, MatrixAddress address)
        {
            HitPoints = 200;
            Id = id;
            Type = type;
            Address = address;
        }

        public void Hit()
        {
            HitPoints -= 3;
        }

        public void MoveTo(MatrixAddress address)
        {
            Address = address;
        }
    }
}