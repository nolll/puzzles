using System;
using Core.AnimatedLights;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day18 : Day2015
    {
        public Day18() : base(18)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var gif = new AnimatedGif(FileInput);
            gif.RunAnimation(100);
            return new PuzzleResult(gif.LightCount, 821);
        }

        public override PuzzleResult RunPart2()
        {
            var gif = new AnimatedGif(FileInput, true);
            gif.RunAnimation(100);
            return new PuzzleResult(gif.LightCount, 886);
        }
    }
}