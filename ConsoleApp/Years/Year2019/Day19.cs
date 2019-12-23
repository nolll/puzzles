using System;
using Core.TractorBeam;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day19 : Day
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tbc = new TractorBeamComputer1(InputData.ComputerProgramDay19, 50, 50);
            var result = tbc.GetPullCount();

            Console.WriteLine($"Number of pulled coordinates: {result}");

            WritePartTitle();
            var tbc2 = new TractorBeamComputer2(InputData.ComputerProgramDay19, 100, 100);
            var result2 = tbc2.Find100By100Square();

            Console.WriteLine($"Checksum size: {result2.Checksum}");
        }
    }
}