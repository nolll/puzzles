using System;
using System.Collections.Generic;

namespace Core.MoonTracking
{
    public class Moon
    {
        private readonly int _firstX;
        private readonly int _firstY;
        private readonly int _firstZ;
        private readonly int _firstVX;
        private readonly int _firstVY;
        private readonly int _firstVZ;

        public int Id { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int VX { get; private set; }
        public int VY { get; private set; }
        public int VZ { get; private set; }

        private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        private int KineticEnergy => Math.Abs(VX) + Math.Abs(VY) + Math.Abs(VZ);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        public long? CycleLength { get; private set; }
        private readonly IList<string> _states;

        public Moon(int id, int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
        {
            Id = id;
            X = _firstX = x;
            Y = _firstY = y;
            Z = _firstZ = z;
            VX = _firstVX = vx;
            VY = _firstVY = vy;
            VZ = _firstVZ = vz;
            _states = new List<string>{GetState()};
        }

        private string GetState()
        {
            return $"{X},{Y},{Z},{VX},{VY},{VZ}";
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

            var state = GetState();

            if(Id == 1)
                Console.WriteLine($"Iteration: {iteration}. Moon {Id}. Cycled: {IsBackToStart(state)}. State: {state}");

            if (CycleLength == null && IsBackToStart(state))
            {
                CycleLength = iteration;
                Console.WriteLine($"Moon {Id} cycle length: {CycleLength}");
            }
            _states.Add(state);
        }

        private bool IsBackToStart(string state)
        {
            return _states.Contains(state);
            return X == _firstX &&
                   Y == _firstY &&
                   Z == _firstZ &&
                   VX == _firstVX &&
                   VY == _firstVY &&
                   VZ == _firstVZ;
        }
    }
}