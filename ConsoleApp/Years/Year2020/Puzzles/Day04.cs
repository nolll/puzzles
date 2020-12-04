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
            var processor = new PassportProcessor(FileInput);
            var passportCount1 = processor.GetNumberOfPassportsThatHasAllFields();
            Console.WriteLine($"Number of passports that has all fields: {passportCount1}");

            WritePartTitle();
            var passportCount2 = processor.GetNumberOfValidPassports();
            Console.WriteLine($"Number of valid passports: {passportCount2}");
        }
    }
}