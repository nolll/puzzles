using System;
using Core.TractorBeam;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day19 : Year2019Day
    {
        public override int Day => 19;

        public override PuzzleResult RunPart1()
        {
            var tbc = new TractorBeamComputer1(FileInput, 50, 50);
            var result = tbc.GetPullCount();

            return new PuzzleResult(result, 141);
        }

        public override PuzzleResult RunPart2()
        {
            var tbc = new TractorBeamComputer2(FileInput, 50, 50);
            var result = tbc.Find100By100Square();

            return new PuzzleResult(result.Checksum, 15_641_348);
        }
    }
}