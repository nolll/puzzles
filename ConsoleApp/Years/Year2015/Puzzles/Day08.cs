using System;
using Core.SantasDigitalList;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day08 : Day2015
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var digitalList = new DigitalList(FileInput);
            Console.WriteLine($"Difference: {digitalList.CodeMinusMemoryDiff}");

            WritePartTitle();
            Console.WriteLine($"Difference: {digitalList.EncodedMinusCodeDiff}");
        }
   }
}