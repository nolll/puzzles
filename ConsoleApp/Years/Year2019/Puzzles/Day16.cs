using System;
using Core.FlawedFrequencyTransmission;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day16 : Day2019
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var algorithm1 = new FrequencyAlgorithmPart1(FileInput);
            var result1 = algorithm1.Run(100);

            Console.WriteLine($"First eight after 100 phases: {result1}");

            WritePartTitle();
            var algorithm2 = new FrequencyAlgorithmPart2(FileInput);
            var result2 = algorithm2.Run(100);

            Console.WriteLine($"Message after 100 phases of long input: {result2}");
        }
    }
}