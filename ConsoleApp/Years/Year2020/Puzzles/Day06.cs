using System;
using Core.AircraftBoarding;
using Core.CustomDeclarations;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day06 : Day2020
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reader = new DeclarationFormReader(FileInput);
            Console.WriteLine($"Sum of 'yes' answers {reader.SumOfYesAnswers}");
        }
    }
}