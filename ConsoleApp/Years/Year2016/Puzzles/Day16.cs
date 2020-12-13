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
            return new PuzzleResult(checksum, "10010010110011010");
        }

        public override PuzzleResult RunPart2()
        {
            var dragonCurve = new DragonCurve();
            var checksum = dragonCurve.Run(Input, 35651584);
            return new PuzzleResult(checksum, "01010100101011100");
        }

        private const string Input = "01000100010010111";
    }
}