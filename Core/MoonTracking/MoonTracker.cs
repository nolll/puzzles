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
        public int CurrentIteration => _iterations + 1;

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

        private bool MaxIterationsReached => RunFixedNumberOfIterations && _iterations >= _maxIterations;
        private bool RunFixedNumberOfIterations => _maxIterations != null;

        private void Run()
        {
            while (!IsDone)
            {
                UpdateVelocities();
                Move();
                Trace();
                _iterations++;
            }
        }

        private bool IsDone => MaxIterationsReached || HasAllCycleLengths;
        private bool HasAllCycleLengths => TotalCycleLength != null && !RunFixedNumberOfIterations;
            
        public long? TotalCycleLength
        {
            get
            {
                if (Moon0.CycleLength == null ||
                    Moon1.CycleLength == null ||
                    Moon2.CycleLength == null ||
                    Moon3.CycleLength == null)
                    return null;

                Console.WriteLine("Cycle lengths complete!");

                var cycleLengths = new List<long>
                {
                    Moon0.CycleLength.Value,
                    Moon1.CycleLength.Value,
                    Moon2.CycleLength.Value,
                    Moon3.CycleLength.Value
                }.Distinct().OrderBy(o => o).ToList();

                var cycleLengthsToUse = new List<long>();
                while (cycleLengths.Any())
                {
                    var currentCycleLength = cycleLengths.First();
                    
                    if(!IsInSync(currentCycleLength, cycleLengths.Skip(1).ToList()))
                        cycleLengthsToUse.Add(currentCycleLength);

                    cycleLengths.RemoveAt(0);
                }

                var firstCycleLength = cycleLengthsToUse.First();
                var otherLengths = cycleLengthsToUse.Skip(1).ToList();
                long totalCycleLength = firstCycleLength;
                foreach (var c in otherLengths)
                {
                    totalCycleLength *= c;
                }

                return totalCycleLength;
            }
        }

        private bool IsInSync(long a, IList<long> list)
        {
            if (!list.Any())
                return false;
            
            return list.Any(o => IsInSync(a, o));
        }

        private bool IsInSync(long a, long b)
        {
            return a % b == 0 || b % a == 0;
        }

        private void Trace()
        {
            const long traceAfter = 1000000;
            if (_iterations % traceAfter == 0)
                Console.WriteLine($"{_iterations / traceAfter}M");
        }

        private void Move()
        {
            var iterationCounter = _iterations + 1;
            Moon0.Move(iterationCounter);
            Moon1.Move(iterationCounter);
            Moon2.Move(iterationCounter);
            Moon3.Move(iterationCounter);
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