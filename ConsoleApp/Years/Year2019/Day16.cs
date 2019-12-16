using System;
using Core.FlawedFrequencyTransmission;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day16 : Day
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var algorithm = new FrequencyAlgorithm(InputData.FlawedFrequencyTransmission);
            var result = algorithm.Run(100);
            var firstEight = result.Substring(0, 8);

            Console.WriteLine($"First eight after 100 phases: {firstEight}");
        }
    }
}