using System;
using Core.AirDuct;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day24 : Day2016
    {
        public Day24() : base(24)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var navigator1 = new AirDuctNavigator(FileInput, false);
            navigator1.Run();
            return new PuzzleResult($"Shortest path: {navigator1.ShortestPath}");
        }

        public override PuzzleResult RunPart2()
        {
            var navigator2 = new AirDuctNavigator(FileInput, true);
            navigator2.Run();
            return new PuzzleResult($"Shortest path including going back to start: {navigator2.ShortestPath}");
        }
    }
}