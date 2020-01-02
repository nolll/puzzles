using System;
using Core.Floors;
using Data.Inputs;

namespace ConsoleApp.Years.Year2015
{
    public class Day01 : Day
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator = new FloorNavigator(InputData.FloorInstructions);
            Console.WriteLine($"Final floor: {navigator.DestinationFloor}");

            WritePartTitle();
            Console.WriteLine($"First basement instruction: {navigator.FirstBasementInstruction}");
        }
    }
}