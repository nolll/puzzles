using System;
using System.Linq;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1Part1();
        }

        private static void Day1Part1()
        {
            var modules = new ModuleRepository().List();
            var requiredFuel = modules.Sum(o => o.RequiredFuel);
            WriteTitle(1, 1);
            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        private static void WriteTitle(int day, int part)
        {
            Console.WriteLine($"Day {day}, part {part}:");
        }
    }
}
