using System;
using Core.GiftWrapping;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day02 : Day2015
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calc = new GiftWrappingCalculator();
            var paperResult = calc.GetRequiredPaper(LegacyInput);
            Console.WriteLine($"Required wrapping paper: {paperResult} square feet");

            WritePartTitle();
            var ribbonResult = calc.GetRequiredRibbon(LegacyInput);
            Console.WriteLine($"Required ribbon: {ribbonResult} feet");
        }
    }
}