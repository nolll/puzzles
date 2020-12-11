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
            return new PuzzleResult($"Most doors required to reach a room: {navigator.MostDoors}");
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new RegularMapNavigator(FileInput);
            return new PuzzleResult($"Number of rooms that passes at least 1000 doors: {navigator.RoomsMoreThat1000DoorsAway}");
        }
    }
}