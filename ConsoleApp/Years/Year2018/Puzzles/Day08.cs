using System;
using Core.NavigationSystemLicense;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day08 : Day2018
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new LicenseNumberCalculator(FileInput);
            Console.WriteLine($"Metadata sum: {calculator.MetadataSum}");

            WritePartTitle();
            Console.WriteLine($"Root node value: {calculator.RootNodeValue}");
        }
    }
}