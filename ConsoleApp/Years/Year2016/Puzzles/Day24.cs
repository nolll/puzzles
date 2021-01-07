using System;
using Core.AirDuct;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day24 : Day2016
    {
        public override string Comment => "Path finding (~10s)";
        public override bool IsSlow => true;

        public Day24() : base(24)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var navigator = new AirDuctNavigator(FileInput, false);
            navigator.Run();
            return new PuzzleResult(navigator.ShortestPath, 502);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new AirDuctNavigator(FileInput, true);
            navigator.Run();
            return new PuzzleResult(navigator.ShortestPath, 724);
        }
    }
}