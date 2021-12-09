﻿using App.Common.Computers.IntCode;
using App.Platform;

namespace App.Puzzles.Year2019.Day09
{
    public class Year2019Day09 : Puzzle
    {
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