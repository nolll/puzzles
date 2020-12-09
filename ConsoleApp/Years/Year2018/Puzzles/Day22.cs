using System;
using System.Linq;
using Core.ModeMaze;
using Core.Tools;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day22 : Day2018
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            var rows = PuzzleInputReader.ReadLines(FileInput);
            var depth = int.Parse(rows.First().Split(' ').Last());
            var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
            var targetX = targetCoords.First();
            var targetY = targetCoords.Last(); 
            
            WritePartTitle();
            var caveSystem = new CaveSystem(depth, targetX, targetY);
            Console.WriteLine($"Total risk level: {caveSystem.TotalRiskLevel}");

            WritePartTitle();
            var time = caveSystem.ResqueMan();
            Console.WriteLine($"Time to resque: {time}");
        }
    }
}