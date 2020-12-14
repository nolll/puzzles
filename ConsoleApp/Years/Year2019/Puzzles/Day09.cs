using System;
using Core.Computer;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day09 : Day2019
    {
        public Day09() : base(9)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var boostTester = new BoostRunner(FileInput, 1);
            var testerResult = boostTester.Run();

            return new PuzzleResult(testerResult.LastOutput, 3_380_552_333);
        }

        public override PuzzleResult RunPart2()
        {
            var boostRunner = new BoostRunner(FileInput, 2);
            var runnerResult = boostRunner.Run();

            return new PuzzleResult(runnerResult.LastOutput, 78_831);
        }
    }
}