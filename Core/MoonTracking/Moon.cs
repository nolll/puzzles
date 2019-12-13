using System;

namespace Core.MoonTracking
{
    public class Moon
    {
        public int Id { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int VX { get; private set; }
        public int VY { get; private set; }
        public int VZ { get; private set; }

        public int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        public int KineticEnergy => Math.Abs(VX) + Math.Abs(VY) + Math.Abs(VZ);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        public int? InitialTotalEnergy { get; }
        public long? CycleLength { get; private set; }

        public Moon(int id, int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
            VX = vx;
            VY = vy;
            VZ = vz;
            InitialTotalEnergy = TotalEnergy;
        }

        public void ChangeVelocity(int x, int y, int z)
        {
            VX = x;
            VY = y;
            VZ = z;
        }

        public void Move(int iteration)
        {
            X += VX;
            Y += VY;
            Z += VZ;
            
            if (CycleLength == null && TotalEnergy == InitialTotalEnergy)
            {
                CycleLength = iteration;
                Console.WriteLine($"Moon {Id} cycle length: {CycleLength}");
            }
        }
    }
}