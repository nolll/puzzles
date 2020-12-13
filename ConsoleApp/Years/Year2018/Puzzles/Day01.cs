using System;
using Core.Frequencies;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day01 : Day2018
    {
        public Day01() : base(1)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var frequencyPuzzle = new FrequencyPuzzle(FileInput);
            var resultingFrequency = frequencyPuzzle.ResultingFrequency;
            return new PuzzleResult(resultingFrequency, 525);
        }

        public override PuzzleResult RunPart2()
        {
            var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(FileInput);
            var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
            return new PuzzleResult(firstRepeatedFrequency, 75_749);
        }
    }
}