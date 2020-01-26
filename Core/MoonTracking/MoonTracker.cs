using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MoonTracking
{
    public class MoonTracker
    {
        public IList<Moon> Moons { get; }
        public long Iterations { get; private set; }
        public int TotalEnergy => Moons.Sum(o => o.TotalEnergy);

        public MoonTracker(string map)
        {
            Moons = ReadMap(map);
        }

        private IList<Moon> ReadMap(string map)
        {
            var rows = map.Trim().Split('\n');
            var moons = new List<Moon>();
            foreach (var row in rows)
            {
                var items = row.Trim().TrimStart('<').TrimEnd('>').Replace(" ", "").Split(',');
                var coords = items.Select(o => int.Parse(o.Split('=')[1])).ToArray();
                var moon = new Moon(coords[0], coords[1], coords[2]);
                moons.Add(moon);
            }
            return moons;
        }

        public void Run(int maxIterations)
        {
            while (Iterations < maxIterations)
            {
                foreach (var dimension in Dimension.Dimensions)
                {
                    UpdateVelocities(dimension);
                    Move(dimension);
                }
                Iterations++;
            }
        }

        public void RunUntilRepeat()
        {
            var iterations = Dimension.Dimensions.Select(o => (long)0).ToArray();
            foreach (var dimension in Dimension.Dimensions)
            {
                while (!IsDone(dimension))
                {
                    UpdateVelocities(dimension);
                    Move(dimension);
                    iterations[dimension] += 1;
                }
            }

            Iterations = MathTools.Lcm(iterations);
        }

        private bool IsDone(int dimension) => Moons.All(o => o.IsBackAtStart(dimension));

        private void Move(int dimension)
        {
            foreach (var moon in Moons)
                moon.Move(dimension);
        }

        private void UpdateVelocities(int dimension)
        {
            for (var i = 0; i < Moons.Count; i++)
            {
                for (var j = 0; j < Moons.Count; j++)
                {
                    if (i != j)
                        UpdateVelocity(dimension, Moons[i], Moons[j]);
                }
            }
        }

        private void UpdateVelocity(int dimension, Moon moon, Moon otherMoon)
        {
            var change = GetVelocityChange(moon.Position[dimension], otherMoon.Position[dimension]);
            moon.ChangeVelocity(dimension, moon.Velocity[dimension] + change);
        }

        private int GetVelocityChange(int moonX, int otherMoonX)
        {
            var diff = otherMoonX - moonX;
            if (diff == 0)
                return 0;

            return diff / Math.Abs(diff);
        }
    }
}