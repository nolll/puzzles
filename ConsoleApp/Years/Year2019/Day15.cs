using System;
using Core.Oxygen;
using Core.OxygenSystem;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day15 : Day
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            //Commented out due to bad implementation that takes a while to complete. Works tho!
            //WritePartTitle();
            //var droid = new RepairDroid(InputData.ComputerProgramDay15);
            //var result1 = droid.Run();

            //Console.WriteLine($"Steps to find oxygen system: {result1}");

            WritePartTitle();
            var filler = new OxygenFiller(InputData.OxygenSystemMap);
            var result = filler.Fill();

            Console.WriteLine($"Number of minutes: {result}");
        }
    }
}