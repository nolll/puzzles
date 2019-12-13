using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.MoonTracking
{
    public class MoonTracker
    {
        private int _iterations = 0;
        private int? _maxIterations;

        public Moon Moon0 { get; }
        public Moon Moon1 { get; }
        public Moon Moon2 { get; }
        public Moon Moon3 { get; }

        public int TotalEnergy => Moon0.TotalEnergy + Moon1.TotalEnergy + Moon2.TotalEnergy + Moon3.TotalEnergy;

        public MoonTracker(string map)
        {
            var moons = ReadMap(map);
            Moon0 = moons[0];
            Moon1 = moons[1];
            Moon2 = moons[2];
            Moon3 = moons[3];
        }

        private IList<Moon> ReadMap(string map)
        {
            var rows = map.Trim().Split('\n');
            var moons = new List<Moon>();
            var i = 0;
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

        public void Run(int? i)
        {
            _maxIterations = i;
            Run();
        }

        private bool MaxIterationsReached => _maxIterations != null && _iterations >= _maxIterations;

        private void Run()
        {
            while (!MaxIterationsReached && !HasAllCycleLengths)
            {
                UpdateVelocities();
                Move();
                //Trace();
                _iterations++;
            }
        }

        private bool HasAllCycleLengths => TotalCycleLength != null;
            
        public long? TotalCycleLength
        {
            get
            {
                if (Moon0.CycleLength == null ||
                    Moon1.CycleLength == null ||
                    Moon2.CycleLength == null ||
                    Moon3.CycleLength == null)
                    return null;

                return Moon0.CycleLength.Value * Moon1.CycleLength.Value * Moon2.CycleLength.Value * Moon3.CycleLength.Value;
            }
        }

        private void Trace()
        {
            if (_iterations % 1000000 == 0)
                Console.WriteLine(_iterations);
        }

        private void Move()
        {
            Moon0.Move(_iterations);
            Moon1.Move(_iterations);
            Moon2.Move(_iterations);
            Moon3.Move(_iterations);
        }

        private void UpdateVelocities()
        {
            UpdateVelocity(Moon0, Moon1);
            UpdateVelocity(Moon0, Moon2);
            UpdateVelocity(Moon0, Moon3);

            UpdateVelocity(Moon1, Moon0);
            UpdateVelocity(Moon1, Moon2);
            UpdateVelocity(Moon1, Moon3);

            UpdateVelocity(Moon2, Moon0);
            UpdateVelocity(Moon2, Moon1);
            UpdateVelocity(Moon2, Moon3);

            UpdateVelocity(Moon3, Moon0);
            UpdateVelocity(Moon3, Moon1);
            UpdateVelocity(Moon3, Moon2);
        }

        private void UpdateVelocity(Moon moon, Moon otherMoon)
        {
            var x = GetVelocityChange(moon.X, otherMoon.X);
            var y = GetVelocityChange(moon.Y, otherMoon.Y);
            var z = GetVelocityChange(moon.Z, otherMoon.Z);
            moon.ChangeVelocity(moon.VX + x, moon.VY + y, moon.VZ + z);
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