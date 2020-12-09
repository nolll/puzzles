using System;
using Core.ReservoirResearch;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day17 : Day2018
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var filler = new ReservoirFiller(FileInput);
            filler.Fill();
            Console.WriteLine($"Total water tile count: {filler.TotalWaterTileCount}");

            WritePartTitle();
            Console.WriteLine($"Retained water tile count: {filler.RetainedWaterTileCount}");
        }
    }
}