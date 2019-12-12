using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.MoonTracking
{
    public class MoonTracker
    {
        private int _iterations = 0;
        private int? _maxIterations;

        public IList<Moon> Moons { get; }

        public MoonTracker(string map)
        {
            Moons = ReadMap(map);
        }

        private IList<Moon> ReadMap(string map)
        {
            var rows = map.Trim().Split('\n');
            var moons = new List<Moon>();
            int i = 0;
            foreach (var row in rows)
            {
                var items = row.Trim().TrimStart('<').TrimEnd('>').Replace(" ", "").Split(',');
                var coords = items.Select(o => int.Parse(o.Split('=')[1])).ToArray();
                var moon = new Moon(i, coords[0], coords[1], coords[2]);
                moons.Add(moon);
                i += 1;
            }
            return moons;
        }

        public void Run(int i)
        {
            _maxIterations = i;
            Run();
        }

        private void Run()
        {
            while (_maxIterations == null || _iterations < _maxIterations)
            {
                UpdateVelocities();
                Move();
                _iterations++;
            }
        }

        private void Move()
        {
            foreach (var moon in Moons)
            {
                moon.Move();
            }
        }

        private void UpdateVelocities()
        {
            foreach (var thisMoon in Moons)
            {
                var otherMoons = Moons.Where(o => o.Id != thisMoon.Id).ToList();
                UpdateVelocity(thisMoon, otherMoons);
            }
        }

        private void UpdateVelocity(Moon moon, IList<Moon> otherMoons)
        {
            foreach (var otherMoon in otherMoons)
            {
                var x = GetVelocityChange(moon.X, otherMoon.X);
                var y = GetVelocityChange(moon.Y, otherMoon.Y);
                var z = GetVelocityChange(moon.Z, otherMoon.Z);
                var oldVelocity = moon.Velocity;
                var newVelocity = new Velocity(oldVelocity.X + x, oldVelocity.Y + y, oldVelocity.Z + z);
                moon.ChangeVelocity(newVelocity);
            }
        }

        private int GetVelocityChange(int moonX, int otherMoonX)
        {
            var diff = otherMoonX- moonX;
            if (diff == 0)
                return 0;

            return diff / Math.Abs(diff);
        }
    }
}