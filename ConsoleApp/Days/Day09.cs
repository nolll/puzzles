using System;
using ConsoleApp.Inputs;
using Core.Computer;

namespace ConsoleApp.Days
{
    public class Day09 : Day
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boostTester = new BoostTester();
            var result = boostTester.Run(InputData.ComputerProgramDay9);

            Console.WriteLine($"BOOST keycode: {result.LastOutput}");
        }
    }
}