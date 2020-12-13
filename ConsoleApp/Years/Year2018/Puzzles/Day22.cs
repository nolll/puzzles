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

        public override PuzzleResult RunPart1()
        {
            var rows = PuzzleInputReader.ReadLines(FileInput);
            var depth = int.Parse(rows.First().Split(' ').Last());
            var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
            var targetX = targetCoords.First();
            var targetY = targetCoords.Last();

            var caveSystem = new CaveSystem(depth, targetX, targetY);
            return new PuzzleResult(caveSystem.TotalRiskLevel, 11_575);
        }

        public override PuzzleResult RunPart2()
        {
            var rows = PuzzleInputReader.ReadLines(FileInput);
            var depth = int.Parse(rows.First().Split(' ').Last());
            var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
            var targetX = targetCoords.First();
            var targetY = targetCoords.Last();
            var caveSystem = new CaveSystem(depth, targetX, targetY);

            var time = caveSystem.ResqueMan();
            return new PuzzleResult(time, 1068);
        }
    }
}