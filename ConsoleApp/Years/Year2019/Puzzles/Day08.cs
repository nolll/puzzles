using System;
using Core.SpaceImages;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day08 : Day2019
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var image = new SpaceImage(FileInput);
            var checksum = image.Checksum;
            return new PuzzleResult(checksum, 1716);
        }

        public override PuzzleResult RunPart2()
        {
            var image = new SpaceImage(FileInput);
            return new PuzzleResult(image.Print(), "KFABY");
        }
    }
}