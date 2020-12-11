using System;
using Core.PassportProcessing;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day04 : Day2020
    {
        public Day04() : base(4)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var processor = new PassportProcessor(FileInput);
            var passportCount = processor.GetNumberOfPassportsThatHasAllFields();
            return new PuzzleResult($"Number of passports that has all fields: {passportCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new PassportProcessor(FileInput);
            var passportCount = processor.GetNumberOfValidPassports();
            return new PuzzleResult($"Number of valid passports: {passportCount}");
        }
    }
}