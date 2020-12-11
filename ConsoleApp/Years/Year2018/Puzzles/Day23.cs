using System;
using Core.ExperimentalEmergencyTeleportation;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day23 : Day2018
    {
        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var formation = new NanobotFormation(FileInput);
            var botCount = formation.GetBotsInRangeOfStrongestBot().Count;
            return new PuzzleResult($"Bots in range of strongest bot: {botCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var formation = new NanobotFormation(FileInput);
            var distanceToBestCoords = formation.FindManhattanDistanceToBestCoords();
            return new PuzzleResult($"Manhattan distance to best coords: {distanceToBestCoords}");
        }
    }
}