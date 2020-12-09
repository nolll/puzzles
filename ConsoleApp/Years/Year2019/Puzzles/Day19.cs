using System;
using Core.TractorBeam;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day19 : Day2019
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tbc = new TractorBeamComputer1(FileInput, 50, 50);
            var result = tbc.GetPullCount();

            Console.WriteLine($"Number of pulled coordinates: {result}");

            WritePartTitle();
            var tbc2 = new TractorBeamComputer2(FileInput, 100, 100);
            var result2 = tbc2.Find100By100Square();

            Console.WriteLine($"Hash size: {result2.Checksum}");
        }
    }
}