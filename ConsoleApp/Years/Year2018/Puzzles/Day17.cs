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
            return new PuzzleResult($"Total water tile count: {filler.TotalWaterTileCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var filler = new ReservoirFiller(FileInput);
            filler.Fill();
            return new PuzzleResult($"Retained water tile count: {filler.RetainedWaterTileCount}");
        }
    }
}