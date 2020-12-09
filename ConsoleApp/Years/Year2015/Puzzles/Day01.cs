using System;
using Core.Floors;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day01 : Day2015
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator = new FloorNavigator(FileInput);
            Console.WriteLine($"Final floor: {navigator.DestinationFloor}");

            WritePartTitle();
            Console.WriteLine($"First basement instruction: {navigator.FirstBasementInstruction}");
        }
    }
}