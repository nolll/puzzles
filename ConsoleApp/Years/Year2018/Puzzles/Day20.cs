using System;
using Core.RegularMap;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day20 : Day2018
    {
        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var navigator = new RegularMapNavigator(FileInput);
            return new PuzzleResult(navigator.MostDoors, 4050);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new RegularMapNavigator(FileInput);
            return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, 8564);
        }
    }
}