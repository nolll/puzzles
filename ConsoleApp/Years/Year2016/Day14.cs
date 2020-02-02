using System;
using Core.OneTimePad;

namespace ConsoleApp.Years.Year2016
{
    public class Day14 : Day
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var generator = new KeyGenerator(Input);
            Console.WriteLine($"Index.of 64th key: {generator.IndexOf64thKey}");
        }

        private const string Input = "zpqevtbw";
    }
}