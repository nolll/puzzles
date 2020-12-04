using System;
using Core.PassportProcessing;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day04 : Day2020
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor = new PassportProcessor();
            var passportCount = processor.GetValidPassportCount(FileInput);
            Console.WriteLine($"Number of valid passports: {passportCount}");
        }
    }
}