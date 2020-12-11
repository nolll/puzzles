using System;
using Core.SubterraneanSustainability;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day12 : Day2018
    {
        public Day12() : base(12)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var spreader = new PlantSpreader(FileInput);
            return new PuzzleResult($"Plant score 20: {spreader.PlantScore20}");
        }

        public override PuzzleResult RunPart2()
        {
            var spreader = new PlantSpreader(FileInput);
            return new PuzzleResult($"Plant score 50 billion generations: {spreader.PlantScore50B}");
        }
    }
}