using System;
using Core.ExperimentalEmergencyTeleportation;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day23 : Day2018
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var formation = new NanobotFormation(FileInput);
            var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
            Console.WriteLine($"Bots in range of strongest bot: {botCount}");

            WritePartTitle();
            var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
            Console.WriteLine($"Manhattan distance to best coords: {distanceToBestCoords}");
        }
    }
}