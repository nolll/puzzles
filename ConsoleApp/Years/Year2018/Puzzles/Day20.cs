using System;
using Core.RegularMap;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day20 : Day2018
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator = new RegularMapNavigator(FileInput);
            Console.WriteLine($"Most doors required to reach a room: {navigator.MostDoors}");

            WritePartTitle();
            Console.WriteLine($"Number of rooms that passes at least 1000 doors: {navigator.RoomsMoreThat1000DoorsAway}");
        }
    }
}