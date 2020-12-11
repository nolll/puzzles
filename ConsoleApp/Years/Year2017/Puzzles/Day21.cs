using System;
using Core.FractalArt;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day21 : Day2017
    {
        public Day21() : base(21)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var artGenerator1 = new FractalArtGenerator(FileInput);
            artGenerator1.Run(5);
            return new PuzzleResult($"Pixels on after 5 iterations: {artGenerator1.PixelsOn}");
        }

        public override PuzzleResult RunPart2()
        {
            var artGenerator2 = new FractalArtGenerator(FileInput);
            artGenerator2.Run(18);
            return new PuzzleResult($"Pixels on after 18 iterations: {artGenerator2.PixelsOn}");
        }
    }
}