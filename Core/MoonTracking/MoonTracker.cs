using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MoonTracking
{
    public class MoonTracker
    {
        public long Iterations { get; private set; }

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

        public void Run(int maxIterations)
        {
            while (Iterations < maxIterations)
            {
                UpdateVelocities();
                Move();
                Iterations++;
            }
        }

        public void RunUntilRepeat()
        {
            var xIterations = 0;
            var xIsDone = false;
            while (!xIsDone)
            {
                UpdateVelocitiesX();
                MoveX();
                xIterations += 1;
                xIsDone = IsXDone();
            }

            var yIterations = 0;
            var yIsDone = false;
            while (!yIsDone)
            {
                UpdateVelocitiesY();
                MoveY();
                yIterations += 1;
                yIsDone = IsYDone();
            }

            var zIterations = 0;
            var zIsDone = false;
            while (!zIsDone)
            {
                UpdateVelocitiesZ();
                MoveZ();
                zIterations += 1;
                zIsDone = IsZDone();
            }

            //var moon0Period = MathTools.Lcm(Moon0.PeriodX, Moon0.PeriodY, Moon0.PeriodZ);
            //var moon1Period = MathTools.Lcm(Moon1.PeriodX, Moon1.PeriodY, Moon1.PeriodZ);
            //var moon2Period = MathTools.Lcm(Moon2.PeriodX, Moon2.PeriodY, Moon2.PeriodZ);
            //var moon3Period = MathTools.Lcm(Moon3.PeriodX, Moon3.PeriodY, Moon3.PeriodZ);

            //var xPeriod = MathTools.Lcm(Moon0.PeriodX, Moon1.PeriodX, Moon2.PeriodX, Moon3.PeriodX);
            //var yPeriod = MathTools.Lcm(Moon0.PeriodY, Moon1.PeriodY, Moon2.PeriodY, Moon3.PeriodY);
            //var zPeriod = MathTools.Lcm(Moon0.PeriodZ, Moon1.PeriodZ, Moon2.PeriodZ, Moon3.PeriodZ);

            //Iterations = MathTools.Lcm(
            //    moon0Period, moon1Period, moon2Period, moon3Period
            //);

            Iterations = MathTools.Lcm(
                xIterations, yIterations, zIterations
            );

            //Iterations = MathTools.Lcm(
            //    Moon0.PeriodX, Moon0.PeriodY, Moon0.PeriodZ,
            //    Moon1.PeriodX, Moon1.PeriodY, Moon1.PeriodZ,
            //    Moon2.PeriodX, Moon2.PeriodY, Moon2.PeriodZ,
            //    Moon3.PeriodX, Moon3.PeriodY, Moon3.PeriodZ
            //);
        }

        private bool IsXDone()
        {
            return Moon0.X == Moon0.StartX && Moon0.Vx == 0 &&
                   Moon1.X == Moon1.StartX && Moon1.Vx == 0 &&
                   Moon2.X == Moon2.StartX && Moon2.Vx == 0 &&
                   Moon3.X == Moon3.StartX && Moon3.Vx == 0;
        }

        private bool IsYDone()
        {
            return Moon0.Y == Moon0.StartY && Moon0.Vy == 0 &&
                   Moon1.Y == Moon1.StartY && Moon1.Vy == 0 &&
                   Moon2.Y == Moon2.StartY && Moon2.Vy == 0 &&
                   Moon3.Y == Moon3.StartY && Moon3.Vy == 0;
        }

        private bool IsZDone()
        {
            return Moon0.Z == Moon0.StartZ && Moon0.Vz == 0 &&
                   Moon1.Z == Moon1.StartZ && Moon1.Vz == 0 &&
                   Moon2.Z == Moon2.StartZ && Moon2.Vz == 0 &&
                   Moon3.Z == Moon3.StartZ && Moon3.Vz == 0;
        }

        private void Move()
        {
            Moon0.Move();
            Moon1.Move();
            Moon2.Move();
            Moon3.Move();
        }

        private void MoveX()
        {
            Moon0.MoveX();
            Moon1.MoveX();
            Moon2.MoveX();
            Moon3.MoveX();
        }

        private void MoveY()
        {
            Moon0.MoveY();
            Moon1.MoveY();
            Moon2.MoveY();
            Moon3.MoveY();
        }

        private void MoveZ()
        {
            Moon0.MoveZ();
            Moon1.MoveZ();
            Moon2.MoveZ();
            Moon3.MoveZ();
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

        private void UpdateVelocitiesX()
        {
            UpdateVelocityX(Moon0, Moon1);
            UpdateVelocityX(Moon0, Moon2);
            UpdateVelocityX(Moon0, Moon3);

            UpdateVelocityX(Moon1, Moon0);
            UpdateVelocityX(Moon1, Moon2);
            UpdateVelocityX(Moon1, Moon3);

            UpdateVelocityX(Moon2, Moon0);
            UpdateVelocityX(Moon2, Moon1);
            UpdateVelocityX(Moon2, Moon3);

            UpdateVelocityX(Moon3, Moon0);
            UpdateVelocityX(Moon3, Moon1);
            UpdateVelocityX(Moon3, Moon2);
        }

        private void UpdateVelocitiesY()
        {
            UpdateVelocityY(Moon0, Moon1);
            UpdateVelocityY(Moon0, Moon2);
            UpdateVelocityY(Moon0, Moon3);
                          
            UpdateVelocityY(Moon1, Moon0);
            UpdateVelocityY(Moon1, Moon2);
            UpdateVelocityY(Moon1, Moon3);
                          
            UpdateVelocityY(Moon2, Moon0);
            UpdateVelocityY(Moon2, Moon1);
            UpdateVelocityY(Moon2, Moon3);
                          
            UpdateVelocityY(Moon3, Moon0);
            UpdateVelocityY(Moon3, Moon1);
            UpdateVelocityY(Moon3, Moon2);
        }

        private void UpdateVelocitiesZ()
        {
            UpdateVelocityZ(Moon0, Moon1);
            UpdateVelocityZ(Moon0, Moon2);
            UpdateVelocityZ(Moon0, Moon3);
                          
            UpdateVelocityZ(Moon1, Moon0);
            UpdateVelocityZ(Moon1, Moon2);
            UpdateVelocityZ(Moon1, Moon3);
                          
            UpdateVelocityZ(Moon2, Moon0);
            UpdateVelocityZ(Moon2, Moon1);
            UpdateVelocityZ(Moon2, Moon3);
                          
            UpdateVelocityZ(Moon3, Moon0);
            UpdateVelocityZ(Moon3, Moon1);
            UpdateVelocityZ(Moon3, Moon2);
        }

        private void UpdateVelocity(Moon moon, Moon otherMoon)
        {
            var x = GetVelocityChange(moon.X, otherMoon.X);
            var y = GetVelocityChange(moon.Y, otherMoon.Y);
            var z = GetVelocityChange(moon.Z, otherMoon.Z);
            moon.ChangeVelocity(moon.Vx + x, moon.Vy + y, moon.Vz + z);
        }

        private void UpdateVelocityX(Moon moon, Moon otherMoon)
        {
            var x = GetVelocityChange(moon.X, otherMoon.X);
            moon.ChangeVelocityX(moon.Vx + x);
        }

        private void UpdateVelocityY(Moon moon, Moon otherMoon)
        {
            var y = GetVelocityChange(moon.Y, otherMoon.Y);
            moon.ChangeVelocityY(moon.Vy + y);
        }

        private void UpdateVelocityZ(Moon moon, Moon otherMoon)
        {
            var z = GetVelocityChange(moon.Z, otherMoon.Z);
            moon.ChangeVelocityZ(moon.Vz + z);
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