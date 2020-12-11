using System;
using Core.DragonChecksum;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day16 : Day2016
    {
        public Day16() : base(16)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var dragonCurve = new DragonCurve();
            var checksum = dragonCurve.Run(Input, 272);
            return new PuzzleResult($"Checksum 1: {checksum}");
        }

        public override PuzzleResult RunPart2()
        {
            var dragonCurve = new DragonCurve();
            var checksum = dragonCurve.Run(Input, 35651584);
            return new PuzzleResult($"Checksum 2: {checksum}");
        }

        private const string Input = "01000100010010111";
    }
}