using System;

namespace AdventOfCode2019
{
    public class Module
    {
        public int Mass { get; }
        public int RequiredFuel { get; }

        public Module(int mass)
        {
            Mass = mass;
            RequiredFuel = GetRequiredFuel(mass);
        }

        private static int GetRequiredFuel(int mass)
        {
            return (int)Math.Floor((double)mass / 3) - 2;
        }
    }
}