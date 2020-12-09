using System;
using Core.Frequencies;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day01 : Day2018
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var frequencyPuzzle = new FrequencyPuzzle(FileInput);
            var resultingFrequency = frequencyPuzzle.ResultingFrequency;
            Console.WriteLine($"Resulting frequency: {resultingFrequency}");

            WritePartTitle();
            var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(FileInput);
            var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
            Console.WriteLine($"First repeat: {firstRepeatedFrequency}");
        }
    }
}