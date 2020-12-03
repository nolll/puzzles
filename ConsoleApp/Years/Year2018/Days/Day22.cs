using System;
using Core.ModeMaze;

namespace ConsoleApp.Years.Year2018.Days
{
    public class Day22 : Day2018
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            const long depth = 11541;
            const int targetX = 14;
            const int targetY = 778;

            WritePartTitle();
            var caveSystem = new CaveSystem(depth, targetX, targetY);
            Console.WriteLine($"Total risk level: {caveSystem.TotalRiskLevel}");

            WritePartTitle();
            var time = caveSystem.ResqueMan();
            Console.WriteLine($"Time to resque: {time}");
        }
    }
}