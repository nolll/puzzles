using System;
using Core.OneTimePad;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day14 : Day2016
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var generator1 = new KeyGenerator(LegacyInput);
            Console.WriteLine($"Index of 64th key: {generator1.IndexOf64thKey}");

            WritePartTitle();
            var generator2 = new KeyGenerator(LegacyInput, true);
            Console.WriteLine($"Index of 64th stretched key: {generator2.IndexOf64thKey}");
        }

        protected override string LegacyInput => "zpqevtbw";
    }
}