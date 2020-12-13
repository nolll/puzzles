using System;
using Core.ReservoirResearch;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day17 : Day2018
    {
        public Day17() : base(17)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var filler = new ReservoirFiller(FileInput);
            filler.Fill();
            return new PuzzleResult(filler.TotalWaterTileCount, 29_802);
        }

        public override PuzzleResult RunPart2()
        {
            var filler = new ReservoirFiller(FileInput);
            filler.Fill();
            return new PuzzleResult(filler.RetainedWaterTileCount, 24_660);
        }
    }
}