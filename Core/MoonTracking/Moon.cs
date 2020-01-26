using System;

namespace Core.MoonTracking
{
    public class Moon
    {
        public int StartX { get; }
        public int StartY { get; }
        public int StartZ { get; }

        private int _iterationsX;
        private int _iterationsY;
        private int _iterationsZ;

        public int Id { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int Vx { get; private set; }
        public int Vy { get; private set; }
        public int Vz { get; private set; }
        public int PeriodX { get; private set; }
        public int PeriodY { get; private set; }
        public int PeriodZ { get; private set; }

        private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        private int KineticEnergy => Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;

        public Moon(int id, int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
        {
            Id = id;
            X = StartX = x;
            Y = StartY = y;
            Z = StartZ = z;
            Vx = vx;
            Vy = vy;
            Vz = vz;
            PeriodX = 0;
            PeriodY = 0;
            PeriodZ = 0;
            _iterationsX = 0;
            _iterationsY = 0;
            _iterationsZ = 0;
        }

        public void ChangeVelocity(int x, int y, int z)
        {
            ChangeVelocityX(x);
            ChangeVelocityY(y);
            ChangeVelocityZ(z);
        }

        public void ChangeVelocityX(int x)
        {
            Vx = x;
        }

        public void ChangeVelocityY(int y)
        {
            Vy = y;
        }

        public void ChangeVelocityZ(int z)
        {
            Vz = z;
        }

        public void Move()
        {
            MoveX();
            MoveY();
            MoveZ();
        }

        public void MoveX()
        {
            X += Vx;
            _iterationsX++;
            if (PeriodX == 0 && X == StartX && Vx == 0)
            {
                PeriodX = _iterationsX;
            }
        }

        public void MoveY()
        {
            Y += Vy;
            _iterationsY++;
            if (PeriodY == 0 && Y == StartY && Vy == 0)
            {
                PeriodY = _iterationsY;
            }
        }

        public void MoveZ()
        {
            Z += Vz;
            _iterationsZ++;
            if (PeriodZ == 0 && Z == StartZ && Vz == 0)
            {
                PeriodZ = _iterationsZ;
            }
        }
    }
}