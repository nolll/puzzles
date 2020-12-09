using System;
using Core.HexGrid;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day11 : Day2017
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator = new HexGridNavigator(FileInput);
            Console.WriteLine($"Last distance: {navigator.EndDistance}");

            WritePartTitle();
            Console.WriteLine($"Max distance: {navigator.MaxDistance}");
        }
    }
}