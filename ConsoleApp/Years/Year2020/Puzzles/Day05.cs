using System;
using Core.AircraftBoarding;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day05 : Day2020
    {
        public Day05() : base(5)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor = new BoardingCardProcessor(FileInput);
            Console.WriteLine($"The boarding card with the highest id is {processor.HighestId}");
        }
    }
}