using System;
using Core.Frequencies;
using Data.Inputs;

namespace ConsoleApp.Years.Year2018
{
    public class Day01 : Day
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var frequencyPuzzle = new FrequencyPuzzle(InputData.FrequencyChanges);
            var resultingFrequency = frequencyPuzzle.ResultingFrequency;
            Console.WriteLine($"Resulting frequency: {resultingFrequency}");

            WritePartTitle();
            var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(InputData.FrequencyChanges);
            var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
            Console.WriteLine($"First repeat: {firstRepeatedFrequency}");
        }
    }
}