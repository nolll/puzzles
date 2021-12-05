using System;
using Core.RegularMap;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Year2018Day20 : Year2018Day
    {
        public override int Day => 20;

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