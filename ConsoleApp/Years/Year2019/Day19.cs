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
            var tbc = new TractorBeamComputer(InputData.ComputerProgramDay19, 50, 50);
            var result = tbc.Run();

            Console.WriteLine($"Number of pulled coordinates: {result.Count}");

            WritePartTitle();
            var tbc2 = new TractorBeamComputer(InputData.ComputerProgramDay19, 100, 100);
            var result2 = tbc2.Run();

            Console.WriteLine($"Square size: {result2.SquareSize}");
        }
    }
}