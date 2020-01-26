using System;

namespace Core.MoonTracking
{
    public class Moon
    {
        private readonly int[] _startPosition;
        private readonly bool[] _hasMoved;

        public int[] Position { get; }
        public int[] Velocity { get; }
        public int X => Position[Dimension.X];
        public int Y => Position[Dimension.Y];
        public int Z => Position[Dimension.Z];
        public int Vx => Velocity[Dimension.X];
        public int Vy => Velocity[Dimension.Y];
        public int Vz => Velocity[Dimension.Z];

        private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        private int KineticEnergy => Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        public bool IsBackAtStart(int dimension) =>
            _hasMoved[dimension] &&
            Position[dimension] == _startPosition[dimension]
            && Velocity[dimension] == 0;

        public Moon(int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
        {
            _hasMoved = new bool[3];
            _startPosition = new[] { x, y, z };

            Position = new[] { x, y, z };
            Velocity = new[] { vx, vy, vz };
        }

        public void ChangeVelocity(int dimension, int velocity)
        {
            Velocity[dimension] = velocity;
        }

        public void Move(int dimension)
        {
            Position[dimension] += Velocity[dimension];
            _hasMoved[dimension] = true;
        }
    }
}