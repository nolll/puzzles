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
            var algorithm1 = new FrequencyAlgorithm(InputData.FlawedFrequencyTransmission);
            var result1 = algorithm1.Run(100);

            Console.WriteLine($"First eight after 100 phases: {result1}");

            //WritePartTitle();
            //var algorithm2 = new FrequencyAlgorithm("03036732577212944063491565474664");
            //var result2 = algorithm2.RunReal(1);

            //Console.WriteLine($"First eight after 100 phases: {result2}");
        }
    }
}